    static void Main(string[] args)
    {
    	//Console.WriteLine("Type number to do factorial on..");
    	int sampleNumber = 5;
    	string sampleNumberAsString = sampleNumber.ToString();
    	var calc = Fact(sampleNumberAsString);
    	Console.WriteLine("Outside fact the answer is " + calc);
    }
    
    
    private static int Fact(string numFact)
    {
    	var number = 1;
    	int factorial = Convert.ToInt32(numFact);
    	for (int i = 1; i <= factorial; i++)
    	{
    		number *= i;
    	}
    	Console.WriteLine($"Inside Fact() local variable number is {number}");//Inside Fact() local variable number is 120
    	Console.WriteLine($"Inside Fact() numFact parameter is is {numFact}");//Inside Fact() numFact parameter is is 5
    	//return numFact;//Clearly I want to return the calculated value (number) not the original value passed in (numFact)
    	//I'm calculating a number so let's not worry about what the caller does with the number
    	//Change the return type to int.
    	return number;
    }
