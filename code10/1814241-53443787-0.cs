    public void MoveRight()
    {
       rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
    
    public void MoveLeft()
    {
       rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
    
    void FixedUpdate ()
	{
		// Add a forward force
		rb.AddForce(0, 0, forwardForce * Time.deltaTime);
		if (Input.GetKey("d"))	// If the player is pressing the "d" key
				MoveRight();
		if (Input.GetKey("a"))  // If the player is pressing the "a" key
	   	        MoveLeft();
    }
