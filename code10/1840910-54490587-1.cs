    int numberOfBonusJumps = 1; //Or however many you want.
    boolean initiallyJumped = false;
    
    //Other stuff
    void Update()
    {
        //Reset jumps BEFORE considering allowing jumps
        if(isGrounded)
        {
            initiallyJumped = false;
            resetJumpCounter();
        }
        
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(!initiallyJumped && isGrounded)
            {
                jump();
                initallyJumped = true;
            }
            else
            {
                if(numberOfBonusJumps > 1)
                {
                    numberOfBonusJumps--;
                    jump();
                }
            }
        }
    }
