    public float timeBetweenChangeSpeed = 3f;
    public float timer = 0;
    
    void Update ()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;
    
        // If 3 seconds passed, time to change speed
        if(timer >= timeBetweenChangeSpeed)
        {
    	    timer = 0f;
    		//Here you call the function to change the random Speed (or you can place the logic directly)
            ChangeRandomSpeed();
        }
    
    }
