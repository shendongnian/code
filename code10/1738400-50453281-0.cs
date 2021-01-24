    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    [RequireComponent(typeof(Rigidbody2D))]
    public class WillOWispFollowPlayer : MonoBehaviour
    {
    
    public Transform target;
    public float smoothSpeed = 0.05f;
    public float smoothSpeedSlow = 0.02f;
    public Vector3 offset;
    public float hoverSpeed = 10000f;
    public Rigidbody2D rb;
    public static System.Timers.Timer hoverTimer;
    public float acceleration;
    public float deceleration;
    private Rigidbody2D physics;
    private Vector2 direction;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("HoverDirection", 0, 1); //calling the DoverDirection every second
        physics = GetComponent<Rigidbody2D>();
        physics.gravityScale = 0;
        physics.drag = deceleration;
    }
    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        Vector3 smoothedPositionSlow = Vector3.Lerp(transform.position, desiredPosition, smoothSpeedSlow);
        //setting up a "wander zone" where the Will'o'the'Wisp is less restricted within a defined distance of the player
        if (Vector3.Distance((target.position + offset), this.transform.position) >= .5)
        {
            transform.position = smoothedPosition;
        }
        else
        {
            transform.position = smoothedPositionSlow;
        }
        //Random direction generator This results in a "flutter" effect
        direction = UnityEngine.Random.insideUnitCircle;
        Vector2 directionalForce = direction * acceleration;
        physics.AddForce(directionalForce * Time.deltaTime, ForceMode2D.Impulse);
    }
    //A regular and prominant directional change, resulting in short darting motions around the target position
    void HoverDirection() 
    {
        rb.velocity = Random.onUnitSphere * hoverSpeed;
    }
    }
