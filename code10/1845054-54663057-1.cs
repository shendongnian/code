    public Rigidbody rb;
    public Transform PlayerPosition;
    // a flag to make sure there is only one animation at a time
    private bool isMoving;
    // a flag for altering between left and right movement
    private bool isMovingRight;
    // Update is called once per frame
    void Update()
    {
        // only allow clicks while not moving already
        if (!isMoving && Input.GetMouseButtonDown(0))
        {
            // stop further input until not moving anymore
            isMoving = true;
            // add the force 
            // (you might btw want to skip that Time.deltaTime here it makes no sense)
            rb.AddForce(isMovingRight ? 20000 : -20000 * Time.deltaTime, 0, 0);
            // alter the direction for the next call
            isMovingRight = !isMovingRight;
            // if you rather want to be able to interrupt the current animation by clicking again
            // remove the isMoving flag and instead use this
            //StopCoroutine(WaitForMoveStops());  
            // Start the routine
            StartCoroutine(WaitForMoveStops());
        }
    }
    private IEnumerator WaitForMoveStops()
    {
        // Inside a Coroutine while is okey now
        // as long as you yield somwhere
        // check if velocity is below threshold
        while (!Mathf.Approximately(rb.velocity.magnitude, 0) 
        {
            // yield in simple words means "leave" this method here, render the frame
            // and than continue from here in the next frame
            yield return null;
        }
        // I would now hard reset the velocity just to be sure
        rb.velocity = Vector3.zero;
        Debug.Log(PlayerPosition.position.x);
     
        // whatever you want to do now
        // reset the flag to allow input again
        isMoving = false;
    }
