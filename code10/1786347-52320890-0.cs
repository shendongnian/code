    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            // the cube is going to move upwards in 10 units per second
            rb2D.velocity = new Vector3(0, 10, 0);
            moving = true;
            Debug.Log("jump");
        }
        if (moving)
        {
            // when the cube has moved over 1 second report it's position
            t = t + Time.deltaTime;
            if (t > 1.0f)
            {
                Debug.Log(gameObject.transform.position.y + " : " + t);
                t = 0.0f;
            }
        }
    }
