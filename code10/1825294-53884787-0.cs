    private float timeUntilSlowEnds = 0;
    private bool isSlowing = false;
    void Update ()
    {
        if (Vector3.Distance (target.position, transform.position) < 20)
        {
            //1/4 second of slow time
            timeUntilSlowEnds = 0.25f;
            isSlowing = true;
        }
        
        if(timeUntilSlowEnds <= 0)
        {
            if(isSlowing)
            {
                //only reset player speed if ending slow
                isSlowing = false;
                player.speed = 10.0f;
            }
        }
        else
        {
            //slow the player each frame and decrease the timer
            player.speed =  5.0f;
            timeUntilSlowEnds -= Time.deltaTime;
        }
    }
