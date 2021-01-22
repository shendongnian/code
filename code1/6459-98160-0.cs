    string s = new Func<string>(() =>
    {
    	string result;
    	
    	try
    	{
    	  result = string.Parse(null);
    	}
    	catch(ArgumentException)
    	{
    	  Console.WriteLine("Failed.");  
    	}
    	
    	return result;
    })();
