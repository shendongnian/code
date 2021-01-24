    class Program
    {
	    static void Main(string[] args)
	    {
		    Operator operatorObject = new Operator();
		    Console.WriteLine("Pick a number:");
		    int result = 0;
		    int userValue;
		    if (int.TryParse(Console.ReadLine(), out userValue))
		    {
			    Console.WriteLine("Pick another number--optional");
			    int userValue2;
			    if (int.TryParse(Console.ReadLine(), out userValue2))
			    {
				    result = operatorObject.operate(userValue, userValue2);
			    }
			    else
			    {
				    result = operatorObject.operate(userValue);
			    }
		    }
		    else
		    {
			    Main(null);
		    }
		    Console.WriteLine(result);
		    Console.ReadLine();
	    }
	
	  ...
}
