    static void Main(string[] args)
    {
    	Console.WriteLine("Type number to do factorial on..");
    	var calc = Fact(Console.ReadLine());
    	Console.WriteLine("The answer is " + calc);
    }
    
    private static int Fact(string numFact)
    {
    	var number = 1;
    	int factorial = Convert.ToInt32(numFact);
    	for (int i = 1; i<= factorial; i++)
    	{
    		number *= i;
    	}
       // Console.WriteLine(number); added to test it works
    	return number;
    }
