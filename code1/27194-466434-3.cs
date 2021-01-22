    // Adjust this to modify the precision
    public const int ITERATIONS = 27;
      
    // power series
    public static decimal DecimalExp(decimal power)
    {
    	int iteration = ITERATIONS;
    	decimal result = 1; 
    	while (iteration > 0)
    	{
    		fatorial = Factorial(iteration);
    		result += Pow(power, iteration) / fatorial;
    		iteration--;
    	}
    }
    
    // natural logarithm series
    public static decimal LogN(decimal number)
    {
    	decimal aux = (number - 1);
    	decimal result = 0;
        int iteration = ITERATIONS;
    	while (iteration > 0)
    	{
    		result += Pow(aux, iteration) / iteration;
    		iteration--;
    	}
    }
    
    // example
    void main(string[] args)
    {
    	decimal baseValue = 1.75M;
    	decimal expValue = 1/252M;
    	decimal result = DecimalExp(expValue * LogN(baseValue));
    }
