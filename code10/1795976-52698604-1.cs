    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)
        {
            transform.Rotate(new Vector3(0, 0, 90), Space.Self);
            rb.velocity = rb.velocity.magnitude*transform.forward;
        }
        else if(Input.GetKeyDown(KeyCode.D)
        {
            transform.Rotate(new Vector3(0, 0, -90), Space.Self);
            rb.velocity = rb.velocity.magnitude*transform.forward;
        }
    }
    
    private void FixedUpdate()
    {
         rb.AddForce(transform.forward * forwardForce * Time.fixedDeltaTime);
    }
