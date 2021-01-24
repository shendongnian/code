        // NEW CODE BEGIN------
    public Vector3 eulerAngleVelocity = new Vector3(0f,0f,1000f);
    // NEW CODE END------
    
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
    // NEW CODE BEGIN------
        Vector3 movement = new Vector3(0f, 0f, moveVertical); // Notice I have removed moveHorizontal, this will make sure your gameobject doesnt go left and right. We will use move horizontal for rotating the gameobject.
    // NEW CODE END------
        rig.velocity = movement * speed;
        rig.position = new Vector3 (Mathf.Clamp (rig.position.x, boundary.xMin, boundary.xMax), 0f, Mathf.Clamp (rig.position.z, boundary.zMin, boundary.zMax));
        // NEW CODE BEGIN------
        Quaternion deltaRotation = Quaternion.Euler(-moveHorizontal * eulerAngleVelocity * Time.deltaTime);
        rig.MoveRotation(rig.rotation * deltaRotation);
        // NEW CODE END------
    }
