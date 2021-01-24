    bool gameOverActionDone = false;
    void Update () 
    {
        if (!gameOver && !gameOverActionDone)
        {
            if (!spawned)
            {
                //Do something
            }
            else if (timer >= 2.0f)
            {
                //Do something else
            }
            else
            {
                timer += Time.deltaTime;
            }
        gameOverActionDone = true;
        }
    }
