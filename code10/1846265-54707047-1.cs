    void Update()
    {
        if (playerInTerritory)
        {
            basicenemy.MoveToPlayer();
        } 
        else 
        {        
            basicenemy.Rest();
        }
    }
