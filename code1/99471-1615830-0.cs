    var groupOne = () => 
    {
    	foreach(string s in new[] { "Good", "Better", "Best" })
    	{
    		Console.WriteLine(s);
    	}
    }
    
    var groupTwo = () => 
    {
    	foreach(string s in new[] { "one", "two", "three" })
    	{
    		Console.WriteLine(s);
    	}
    }
    
    List<Action> acts = new List<action> { groupOne, groupTwo };
    foreach(var a in acts)
    {
    	a();
    }
