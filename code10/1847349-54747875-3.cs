    public Example PButton;
    void SlashAttack () 
    {
        // ...
    
        // Ataque a distancia
        if (Input.GetKeyDown("p") || Input.GetKeyDown(KeyCode.Z) || PButton.isDown)
        { 
            // ...
        } 
        else if (Input.GetKeyUp("p") || Input.GetKeyUp(KeyCode.Z) || PButton.isUp)
        { 
            // ...
        } 
        
        // ...
    }
