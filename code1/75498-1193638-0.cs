    using System;
    
    class Program
    {
    	static void Main()
    	{
    		double _west = 9.482935905456543;
    		double _off = 0.00000093248155508263153;
    		double _lon = _west + _off;
    
    		// check for the expected result
    		Console.WriteLine(_lon == 9.48293683793809808263153);		
    	}
    }
