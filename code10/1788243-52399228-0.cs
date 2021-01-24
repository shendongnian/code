    var prev = 0;
    List<int> bag = null;
    var result = new List<List<int>>();
    foreach(var item in list)
    {
    	if(item.Val == 1)
    	{
    		if(prev == 0)
    		{
    			if(bag != null)
    				result.Add(bag);
    			bag = new List<int>();
    		}						
    		bag.Add(item.Id);
    	}
    	prev = item.Val;
    }
    if(bag != null)
    	result.Add(bag);
    result.ForEach(x => {			
	    Console.WriteLine(String.Join(", ", x));
	});
    //3, 4, 5, 6
    //11, 12
