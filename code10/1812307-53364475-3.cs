    private void sprintInput()
    {
        if (!isCrouching  && Input.GetKeyDown(sprintKey))
        {           
            movementSpeed *= 2f;
        }
        if (!isCrouching && Input.GetKeyUp(sprintKey))
        {          
            movementSpeed /= 2f;
        }
    }
