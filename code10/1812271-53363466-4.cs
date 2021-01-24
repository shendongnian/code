	void Main()
	{
		string result;
	    Console.Write("Enter a Number : ");
		//while (!int.TryParse((result = Console.ReadLine()), out _))
        while (!IsNumericCustom((result = Console.ReadLine()))
		{
	        Console.WriteLine("Please Enter Numbers Only.");
	    	Console.Write("Enter a Number : ");
		}
	    Console.WriteLine($"Entered String: {result} is a Number!");
		Console.ReadKey();
	}
	
    public bool IsNumericCustom(string input)
    {
        //...
    }
