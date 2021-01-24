    void Update ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
    
        HandleMovement(moveHorizontal);
    
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)//by typing Space player jumps, cant double-jump
        {
            rgdb2.AddForce(new Vector2(rgdb2.velocity.x, 1 * jumpHeight), ForceMode2D.Impulse);
    
            isJumping = true;
    
            Debug.Log("jumped");
        }
    }
