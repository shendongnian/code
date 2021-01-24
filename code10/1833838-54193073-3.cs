    static void Main(string[] args)
    {
    	var numbers = new List<int>();
    	var run=true;
    	while(true)
    	{
    		var input = Console.ReadLine();
    		if(input.Equals("q"))
    		{
    			break;
    		}
    				
    		if(Int32.TryParse(input,out var value))
    		{
    			numbers.Add(value);
    		}
    	}
    			
    	var result = numbers
    				.Select((t,i) => new { Index = i, Value = t })
    				.GroupBy(g => g.Value)
    				.Where(g => g.Count() > 1);
    	foreach(var group in result)
    	{
    		var groupItems = group.ToList();
    		Console.WriteLine($"Your {string.Join(", ",groupItems.Take(groupItems.Count()-1).Select(x=> AddOrdinal(x.Index+1)))} and {AddOrdinal(groupItems.Last().Index+1)} are equal");
    	}
    	
    }
    
    public static string AddOrdinal(int num)
    {
        if( num <= 0 ) return num.ToString();
    
        switch(num % 100)
        {
            case 11:
            case 12:
            case 13:
                return num + "th";
        }
    
        switch(num % 10)
        {
            case 1:
                return num + "st";
            case 2:
                return num + "nd";
            case 3:
                return num + "rd";
            default:
                return num + "th";
        }
    
    }
