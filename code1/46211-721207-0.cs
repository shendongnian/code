    using System;
    
    class Program
    {
    	static void Main()
    	{
    		char c = 'A';
    		int i = 65;
    
            // both print "True"
    		Console.WriteLine(i == (int)c);
    		Console.WriteLine(c == (char)i);
    	}
    }
