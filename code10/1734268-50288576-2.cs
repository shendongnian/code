    static void Main(string[] args)
    {
    	string str = "P ,B ,B P,P ,T ,P ,P B";
    	string result = string.Empty;
    
    	string[] newChars = str.Split(',');
    
    	foreach (string previousValue in newChars)
    	{
    		if (previousValue.Trim().Length > 1)
    		    result += previousValue.Trim().First().ToString().Trim() + " ,";
    		else
    		    result += previousValue.Trim() + " ,";
    	}
    
    	result = result.Trim(',');
    
    	Console.WriteLine(str);
    	Console.WriteLine(result);
    	Console.ReadLine();
    }
    Compact Solution using LINQ
    static void Main(string[] args)
    {
    	string str = "P ,B ,B P,P ,T ,P ,P B";
    	string result = string.Empty;
    
    	string[] newChars = str.Split(',').Select(s => s.Trim()).ToArray();
    
    	result = string.Join(" ,", newChars.Select(s => s.Length > 1 ? s.First().ToString() : s)); 
    
    	Console.WriteLine(str);
    	Console.WriteLine(result);
    	Console.ReadLine();
    }
