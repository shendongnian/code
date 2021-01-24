	void Main()
	{
		int result;
	    Console.Write("Enter a Number : ");
		while (!int.TryParse(Console.ReadLine(), out result))
		{
	        Console.WriteLine("Please Enter Numbers Only.");
	    	Console.Write("Enter a Number : ");
		}
	    Console.WriteLine($"Entered String: {result} is a Number!");
		Console.ReadKey();
	}
	
		
