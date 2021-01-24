    public int Calculate()
    {
    	int thisRoll = 0;		// only accessible from inside the method
    	
    	for (int i = 0; i < 4; i++)
    	{
    		int num = Random.Range(0,2); // Either 1 or 0.
    
    		thisRoll = thisRoll + num; // num is added to total result
    		if (thisRoll > 4)
    		{
    			Debug.Log("Rolling " + thisRoll + " not possible!!");
    		}
    	}
    	return thisRoll;
    }
    
    void onClick()
    {
    	//resultReset();		// not necessary anymore
    
    	int iRolled = Calculate();
    	Debug.Log("I rolled " + iRolled); // Sometimes gives 5+ and skips the for loop (like, goes 1-2 times and gives out an impossible number)
    	
    	// set result here if you actually need it in addition to iRolled:
    	result = iRolled;
    }
