    var value = new StringBuilder();
    var run = true;
    while (run)
    {
    	var inputKey = Console.ReadKey(true);
    	switch (inputKey.Key)
    	{
    		case ConsoleKey.Enter:
    			run = false;
    			Console.WriteLine();
    			break;
    		case ConsoleKey.Backspace:
    			value.Append(inputKey.KeyChar);
    			break;
    		default:
    			if (!char.IsDigit(inputKey.KeyChar))
    				value.Append(inputKey.KeyChar);
    			Console.Write(inputKey.KeyChar);
    			break;
    	}
    	
    }
    
    var name = value.ToString();      
