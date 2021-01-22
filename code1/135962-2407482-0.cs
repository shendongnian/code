    private static void RecurseSome(int number)
    {
    	lock (obj)
    	{
    		RecurseSomeImp(number);
    	}
    }
    private static void RecurseSomeImp(int number)
    {
    	Console.WriteLine(number);
    	if( number < 100 ) // Add a boundary condition
    		RecurseSomeImp(++number);
    }
