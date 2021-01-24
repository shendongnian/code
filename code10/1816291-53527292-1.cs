    public void StartTest()
    {
    	var actions = new List<Action>();
    	for (int i = 0; i < 6; i++)
    	{
    		// you can't pass 'i' directly to the Action here,
    		// because 'i' is in the scope of where the Action is executed
    		// and since the parameter of the Action is first evaluated at the 
    		// execution of the Action if you were to put 'i' it checks what value
    		// 'i' has at the current point in time and since the for-loop finished
    		// already it is always going to be 6
    		var word = $"Word: {i}";
    		actions.Add(() => Function1(word));
    	}
    	
    	// you could interpret the lambda 'action => action()' as
    	// foreach(var action in actions)
    	//     action();
    	// so it essentially tells you what it's going to do for each
    	// Action Item in the Action-Collection you passed as Parallel.ForEach's first parameter,
    	// while 'action' represents the "current" item
    	Parallel.ForEach(actions, new ParallelOptions{MaxDegreeOfParallelism = 2}, action => action());
    
    	Console.WriteLine("Finished. \nTime Taken: " + total.ToString(@"dd\.hh\:mm\:ss"));
    	Console.Read();
    }
    
    
    private void Function1(string word)
    {
    	for (int i = 0; i < 5; i++)
    		Console.WriteLine(word + " |  Task Id: " + Task.CurrentId + " |   " + i);
    	
    	Console.WriteLine(word + " ----- Completed.");
    }
