      void FixedUpdate () {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rig.velocity = movement * speed;
        rig.position = new Vector3 (Mathf.Clamp (rig.position.x, boundary.xMin, boundary.xMax), 0f, Mathf.Clamp (rig.position.z, boundary.zMin, boundary.zMax));
        if(moveHorizontal > 0){ //if your "right key" is pressed
          // Rotate the object around its local X axis at 1 degree per second
          transform.Rotate(Vector3.right * Time.deltaTime);
        }
    }
