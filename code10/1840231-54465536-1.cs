    private async Task<string[]> SearchAsync()
    {
    	var i = 1;
    	
    	var tasks = new List<Task<string>>();
    	
    	//Create the tasks
    	while (i < 5)
    	{
    		string url = "https://jsonplaceholder.typicode.com/posts/" + i;
    		tasks.Add(GetData(url));
    		i++;
    	}
    	
    	//Wait for the tasks to complete and return
    	return await Task.WhenAll(tasks);
    }
