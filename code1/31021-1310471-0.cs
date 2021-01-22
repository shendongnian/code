    static void Main(string[] args)
    {
    	// Setup
    	CommandHandler handler = new CommandHandler();
    	CommandOptions options = new CommandOptions();
    
    	// Add some commands. Use the v syntax for passing arguments
    	options.Add("show", handler.Show)
    		.Add("connect", v => handler.Connect(v))
    		.Add("dir", handler.Dir);
    
    	// Read lines
    	System.Console.Write(">");
    	string input = System.Console.ReadLine();
    
    	while (input != "quit" && input != "exit")
    	{
    		if (input == "cls" || input == "clear")
    		{
    			System.Console.Clear();
    		}
    		else
    		{
    			if (!string.IsNullOrEmpty(input))
    			{
    				if (options.Parse(input))
    				{
    					System.Console.WriteLine(handler.OutputMessage);
    				}
    				else
    				{
    					System.Console.WriteLine("I didn't understand that command");
    				}
    
    			}
    			
    		}
    
    		System.Console.Write(">");
    		input = System.Console.ReadLine();
    	}
    }
