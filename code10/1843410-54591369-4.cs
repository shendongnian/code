    public class Thing
    {
    	public string Name { get; set; }
    	public bool? Approved { get; set; }
    }
    
    public class ApprovedComparer : IComparer<bool?>
    {
    	public int Compare(bool? x, bool? y)
    	{
    		var a = 0;
    		var b = 0;
    
    		if (x.HasValue)
    			a = x.Value ? 1 : 2;
    		if (y.HasValue)
    			b = y.Value ? 1 : 2;
    
    		return a - b;
    	}
    }
    
    void Main()
    {
    	var thing1 = new Thing { Approved = null, Name = "Thing 1" };
    	var thing2 = new Thing { Approved = true, Name = "Thing 2", };
    	var thing3 = new Thing { Approved = false, Name = "Thing 3" };
    
    	//note the 'incorrect' order
    	var listOfThings = new[] { thing3, thing2, thing1 };
    
    	listOfThings
    		.OrderBy(x => x.Approved, new ApprovedComparer())
    		.Select(x => x.Name) //just for outputting the names
    		.Dump(); //LinqPad specifc
    }
