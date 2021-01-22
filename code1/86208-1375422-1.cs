    using System;
    using System.IO;
    
    class Program
    {
    	static void Main()
    	{
    		String[] values = File.ReadAllText(@"d:\test.csv").Split(',');
    	}
    }
