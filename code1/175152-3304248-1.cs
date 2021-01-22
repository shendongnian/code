    void Main()
    {
    	object [] f = new object []{ 1, "blah", 4 };
    	Test( f );
    	Console.WriteLine("{0}, {1}, {2}", f[0], f[1], f[2]);
        // output
        // 2, blah, 5 
    }
    
    void Test ( object[] parameters )
    {
    	for(int ii = 0; ii < parameters.Length; ii++)
    	{
    		if(parameters[ii] is int) 
    			parameters[ii] = (int)parameters[ii] + 1;
    	}
    }
