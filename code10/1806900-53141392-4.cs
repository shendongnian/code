    float counterTask1 = 3f;
    float counterTask2 = 2f;
    float timer;
    bool chooseTask;
    
    void Start(){
    	//Initialize timer with value 0
    	timer = 0;
    	chooseTask = 1;
    }
    
    void Update ()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;
    
        // This will trigger an action every 2 seconds
    	if(chooseTask && timer >=  counterTask1)
        {
    		timer = 0f;
    		chooseTask = 0;
            #Do Task 1 Here
        }else if(!chooseTask && timer >= counterTask2)
    	{
    		timer = 0f;
    		chooseTask = 1;
            #Do Task 2 Here
    	}
    }
