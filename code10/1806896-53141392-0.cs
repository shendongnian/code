       float timeBetweenActions = 2f;
        float timer;
        
        void Start(){
        	//Initialize timer with value 0
        	timer = 0;
        }
        
        void Update ()
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;
        
            // This will trigger an action every 2 seconds
            if(timer >= timeBetweenActions)
            {
        		timer = 0f;
                DoSomethingHere();
            }
        
        }
