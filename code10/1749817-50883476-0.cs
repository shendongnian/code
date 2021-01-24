    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class PlanetPush : MonoBehaviour {
    [SerializeField] Transform target;
    [SerializeField] float range = 1000;
    [SerializeField] float pushingspeed = 0.01f;
    [SerializeField] float DampSpeed = 0.1f;
    float MaxPlayerSpeed = 30f;
    // Update is called once per frame
    void Update ()
    {
        //Check if is in range
        if (Vector3.Distance(target.position, transform.position) < range)
        { 
            Debug.DrawLine(transform.position, target.position, Color.green);
            pushingspeed += DampSpeed;
            if (pushingspeed >= MaxPlayerSpeed)
            {
                pushingspeed = MaxPlayerSpeed;
            }
            //Push away from object
            target.position = Vector3.MoveTowards(target.position, transform.position, Time.deltaTime * -pushingspeed);
        }
        else
        {
            Debug.DrawLine(transform.position, target.position, Color.yellow);
            pushingspeed = 0.1f;
        }
    }
    }
