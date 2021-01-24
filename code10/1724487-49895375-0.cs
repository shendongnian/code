    void Main()
    {
    	List<string> StringList = new List<string>()
    	{
    		"A", "B", "C", "D", "E", "F"
    	};
    	
    	var query =
    		StringList
    			.ToObservable()
    			.SelectMany(c => Observable.FromAsync(() => Push(c)))
    			.ToArray();
    	
    	var result = query.Wait();
    	
    	Console.WriteLine(String.Join(", ", result));
    }
    
    public Task<string> Push(string input)
    {
    	return Task.Factory.StartNew(() =>
    	{
    		var id = System.Threading.Thread.CurrentThread.ManagedThreadId;
    		Console.WriteLine($"Executing {input} on Thread: {id}");
    		return input;
    	});
    }
