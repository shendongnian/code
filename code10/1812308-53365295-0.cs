    bool isCrouching, isSprinting;
    float baseSpeed, movementSpeed;
    private void sprintInput {
        if (Input.GetKeyDown(sprintKey)) {        
            isSprinting = true;
            UpdateSpeed ();
        }
        if (Input.GetKeyUp(sprintKey)) {
            isSprinting = false; 
            UpdateSpeed ();
        }
    }
    private void crouchInput {
        if (Input.GetKeyDown(crouchKey)) {        
            isCrouching = true;
            UpdateSpeed ();
        }
        if (Input.GetKeyUp(crouchKey)) {
            isCrouching = false; 
            UpdateSpeed ();
        }
    }
    private void UpdateSpeed () {
        movementSpeed = isCrouching ? baseSpeed / 2
                      : isSprinting ? baseSpeed * 2
                      :               baseSpeed;
    }
