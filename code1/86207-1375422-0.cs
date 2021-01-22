    using System;
    using System.IO;
    
    class Program
    {
    	static void Main()
    	{
            String[] values = File.OpenText(@"d:\test.csv")
                                  .ReadToEnd()
                                  .Split(',');
    	}
    }
