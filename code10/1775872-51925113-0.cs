    class Program
    {
    	static int add ( params int [ ] number )
    	{
    		int sum = 0;
    		foreach ( int n in number )
    		{
    			sum=sum+n;
    		}
    		return sum;
    	}
    	static void Main(string[] args)
    	{
    		// passing three parameters
    		//Program conv = new Program(); // NO NEED OF THIS.
    		Console.Write("The sum of the given number is: ");
    		Console.Write("{0:0.0}", add(1, 2, 3)); // CHANGE
    
    		Console.ReadLine();
    	}
    }
