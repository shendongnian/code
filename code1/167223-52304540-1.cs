    try
    {
    	string num = "100";
    	int value;
    	bool isSuccess = int.TryParse(num, out value);
    	if(isSuccess)
    	{
    		value = value + 1;
    		Console.WriteLine("Value is " + value);
    	}
    }
    catch (FormatException e)
    {
    	Console.WriteLine(e.Message);
    }
