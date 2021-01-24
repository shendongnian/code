    private void SetMovement() // Input handler in Update
    {
        // keep our y velocity on the rigidbody....
        movement.y = rigidbody.velocity.y;
        float horizontalInput = Input.GetAxisRaw(StringCollection.INPUT_HORIZONTAL);
    
        horizontalInput *= Input.GetKey(KeyCode.LeftShift) ? MOVEMENT_SPEED_RUN : MOVEMENT_SPEED_WALK;
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (groundCheck.IsGrounded) // Default jump from the ground
            {
                // only instantly override x when we are on the ground.
                movement.x = horizontalInput;
                groundJumpPressed = true;
            }
            else // **not** grounded
            {
                // since we are in the air, slowly lower or increase our 
                // change in direction using time.deltatime
                movement.x += horizontalInput * time.deltaTime;
                // clamp our values between our max and minimum speed.
                movement.x = Mathf.Clamp(movement.x, -MOVEMENT_SPEED_RUN, MOVEMENT_SPEED_RUN);
                if (wallCheck.IsCloseToWall) // jump from the wall
                {
                    wallJumpPressed = true;
                }
            }
        }
        else
        {
            if (groundCheck.IsGrounded) // Default jump from the ground
            {
                // only instantly override x when we are on the ground.
                movement.x = horizontalInput;
            }
            else // **not** grounded
            {
                // since we are in the air, slowly lower or increase our 
                // change in direction using time.deltatime
                movement.x += horizontalInput * time.deltaTime;
                // clamp our values between our max and minimum speed.
                movement.x = Mathf.Clamp(movement.x, -MOVEMENT_SPEED_RUN, MOVEMENT_SPEED_RUN);
            }
        }
    }
    private void Move()
    {
        if (groundCheck.IsGrounded)
        {
            if (groundJumpPressed) // Default jump from the ground
            {
                movement.y = JUMP_POWER;
                groundJumpPressed = false;
            }
        }
        else
        {
            if (wallCheck.IsCloseToWall)
            {
                if (wallJumpPressed) // Walljump
                {
                    // jump away from wall
                    wallJumpPressed = false;
                    // negate movement when we jump to the opposite direction
                    // With changes to SetMovement, we can't just 0 out the 
                    // movement.x since we are in the air.
                    movement.x *= -1;  
                }
            }
        }
    
        if (movement != Vector2.zero)
        {
            rigid.velocity = movement; // move the player
        }
    }
