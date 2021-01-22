    public void Test_SortArrayList()
    {
    	ArrayList items = new ArrayList(new []{"1", "10", "2", "15", "17", "5", "6", "27", "8", "9"});
    	string[] strings = (string[])items.ToArray(typeof(string));
    	List<string> result = strings
    		.Select(x => new
    			{
    				Original = x,
    				Value = Int32.Parse(x)
    			})
    		.OrderBy(x => x.Value)
    		.Select(x => x.Original)
    		.ToList();
    	result.ForEach(Console.WriteLine);
    }
    
