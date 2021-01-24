    static void Main(string[] args)
    {
    	bool isValid = false;
    
    	do {
    		Console.WriteLine("Please enter the current day of the week.");
    		string currentday = Console.ReadLine();
    
    		isValid = Enum.IsDefined(typeof(days), currentday);
    
    		if (isValid)
    		{
    			Console.WriteLine("Good job.  Today is " + currentday);
    		}
    		else
    		{
    			Console.WriteLine("Not a valid day");
    		}
    	} while (!isValid);            
    
    	Console.ReadLine();
    }
