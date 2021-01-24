    enum ByteMassFactor { B = 1, KB = 1024, MB = 1024 * 1024, GB = 1024 * 1024 * 1024 }
    
    void Main()
    {
    	var byteCount = 2048;
    
    	foreach (var mass in Enum.GetValues(typeof(ByteMassFactor)).Cast<ByteMassFactor>().Reverse())
    		if (byteCount / (int)mass >= 1)
    		{
    			Console.WriteLine($"{byteCount / (int)mass} {mass}");
    			break;
    		}
    }
