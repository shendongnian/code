	public static void Main()
	{
        Operator operatorObject = new Operator();
        Console.WriteLine("Pick a number:");
        int userValue = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Pick another number--optional");
		
		int userValue2;
		int result;
		if(int.TryParse(Console.ReadLine(), out userValue2))
		{
			 result = operatorObject.operate(userValue,userValue2);
		} 
		else 
		{
			 result = operatorObject.operate(userValue);
		}
		
        Console.WriteLine(result);
        Console.ReadLine();
	}
