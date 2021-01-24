    int numberOfJumps = 1; //Or however many you want.
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
                int jumpsRemaining = numberOfJumps;
                if(initiallyJumped)
                {
                    jumpsRemaining--;
                }
                
                if(numberOfJumps > jumpsRemaining)
                {
                    jump();
                    numberOfJumps--;
                }
            }
        }
    }
