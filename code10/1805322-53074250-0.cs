    if ((Input.GetButtonDown("Jump")))
        {
            jump = true;
           
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {  
             if(!animator.GetBool("IsJumping")){
            crouch = true;
            runSpeed = 0f;
            }
    
        }else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            runSpeed = 20f;
        }
