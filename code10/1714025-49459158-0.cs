    void getInput()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Physics2D.IgnoreLayerCollision(9, 8, true);
    
            playerCollider.enabled = false;
            platformCollider.enabled = false;
            playerCollider.enabled = true;
            platformCollider.enabled = true;
        }
        else if(Input.GetKeyUp(KeyCode.S))
        {
            Physics2D.IgnoreLayerCollision(9, 8, false);
        }
    }
