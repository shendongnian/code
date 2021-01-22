    public static void PassValue(decimal value)
    {
     
    }
    
    public static void PassRef(ref decimal value)
    {
     
    }            
    		
    decimal passMe = 0.00010209230982047828903749827394729385792342352345m;
    
    for (int x = 0; x < 20; x++)
    {
    	DateTime start = DateTime.UtcNow;
    	TimeSpan taken = new TimeSpan();
    
    	for (int i = 0; i < 50000000; i++)
    	{
    		PassValue(passMe);
    	}
    
    	taken = (DateTime.UtcNow - start);
    	Console.WriteLine("Value : " + taken.TotalMilliseconds);
    
    	start = DateTime.UtcNow;
    
    	for (int i = 0; i < 50000000; i++)
    	{
    		PassRef(ref passMe);
    	}
    
    	taken = (DateTime.UtcNow - start);
    	Console.WriteLine("Ref : " + taken.TotalMilliseconds);
    }
