    bool gameOverActionDone = false;
    void Update () 
    {
        if (!gameOver && !gameOverActionDone)
        {
            if (!spawned)
            {
                //Do something
                gameOverActionDone = true;
            }
            else if (timer >= 2.0f)
            {
                //Do something else
                gameOverActionDone = true;
            }
            else
            {
                timer += Time.deltaTime; //either keep this here, or move it out if the if condition entirely
            }
        }
    }
