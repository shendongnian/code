    // NEW CODE ------
    public Vector3 eulerAngleVelocity = new Vector3(0f,0f,1000f);
    // NEW CODE ------
    
    void FixedUpdate () {
    	float moveHorizontal = Input.GetAxis ("Horizontal");
    	float moveVertical = Input.GetAxis ("Vertical");
    	Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
    	rig.velocity = movement * speed;
    	rig.position = new Vector3 (Mathf.Clamp (rig.position.x, boundary.xMin, boundary.xMax), 0f, Mathf.Clamp (rig.position.z, boundary.zMin, boundary.zMax));
    	// NEW CODE ------
    	Quaternion deltaRotation = Quaternion.Euler(-moveHorizontal * eulerAngleVelocity * Time.deltaTime);
    	rig.MoveRotation(rig.rotation * deltaRotation);
    	// NEW CODE ------
    }
