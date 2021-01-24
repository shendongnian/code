    static string[] LoadWords()
    {
    	string[] WordsArray = null;	
    	Console.WriteLine("Please enter the name of a file:");
    	
    	do
    	{
    		try
    		{  
    			string filename = Console.ReadLine();
    			if (File.Exists(filename))
    				WordsArray = File.ReadAllLines(filename);
    			else
    				Console.WriteLine($"{Environment.NewLine} File does not exist, try again: ");
    		}
    		catch (Exception ex)
    		{
    			Console.WriteLine($"{Environment.NewLine} Unknown exception, exiting. {ex.Message}");
    			return null;
    		}
    	}
    	 while (WordsArray == null)
    	
    	return WordsArray;
    }
