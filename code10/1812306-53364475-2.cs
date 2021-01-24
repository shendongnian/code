    bool isCrouching;
    
    private void crouchInput()
    {
        if (Input.GetKeyDown(crouchKey))
        {        
            isCrouching = true;   
            movementSpeed /= 2f;
        }
        if (Input.GetKeyUp(crouchKey))
        {
            isCrouching = false; 
            movementSpeed *= 2f;
        }
    }
