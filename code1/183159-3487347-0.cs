    //By naming the rangeX variables something meaningful you can make your code more readable(in my mind).
    var range1 = new int[] { 1, 2, 3 };
    var range2 = new int[] { 4, 5 };
    var range3 = new int[] { 6 };
    
    for(int i = 0; i < 20; i++)
    {
    	if(range1.Contains(i)) 
    	{
    	  //Do stuff
    	}
    	else if(range2.Contains(i)) 
    	{
    	  //Do other stuff
    	}
    	//etc
    }
