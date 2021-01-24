    int numberOfBonusJumps = 1; //Or however many you want.
    //Other stuff
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(isGrounded)
            {
                jump();
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
        else if(isGrounded) //Only reset the jump counter if no jump input is being received
        {
            resetJumpCounter();
        }
    }
