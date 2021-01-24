    var wasMovingLastTime = false;    
    
    void Update()
    {
        var isMoving = rb.velocity.magnitude > 0f;
        
        if (wasMovingLastTime && !isMoving)
        {
            /// Has just finished moving
            Debug.Log(PlayerPosition.position.x);
        }
    
        if (Input.GetMouseButtonDown(0))
        {
            if (!isMoving)
            {
                rb.AddForce(20000 * Time.deltaTime, 0, 0);
            }
        }
        wasMovingLastTime = isMoving;
    }
