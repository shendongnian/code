    bool jump_pressed = false;
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            jump_pressed = true;
        }
        if(Input.GetKeyUp("space"))
        {
            jump_pressed = false;
        }
    }
    void FixedUpdate()
    {
        if(jump_pressed)
        {
            jump_pressed = false;
            rb.AddForce(0, 10, 0, ForceMode.VelocityChange);
            // etc...
        }
    }
