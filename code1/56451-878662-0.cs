    using System;
    
    class Program
    {
    	static void Main()
    	{
    		Func<Int32, String> func = bar;
    
    		// now I have a delegate which 
    		// I can invoke or pass to other
    		// methods.
    		bar(1);
    	}
    
    	static String bar(Int32 value)
    	{
    		return value.ToString();
    	}
    }
