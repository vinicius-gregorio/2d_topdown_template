using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Player player;
    private Animator animation;

    void Start()
    {
        player = GetComponent<Player>();
        animation = GetComponent<Animator>();
    }

    void Update()
    {
       OnMove();
       OnRun();
    }


    #region Movement
    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            Debug.Log("Moving");
            if (player.isRolling)
            {
                animation.SetTrigger("isRoll");
                Debug.Log("Roll");

            }
            else
            {
                animation.SetInteger("transition", 1);
                Debug.Log("Walk");

            }
        }
        else
        {
            Debug.Log("Stop Moving");

            animation.SetInteger("transition", 0);
        }

        if (player.direction.x > 0) 
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void OnRun()
    {
        if(player.isRunning)
        {
            animation.SetInteger("transition", 3);
        }
    }
    #endregion
}
