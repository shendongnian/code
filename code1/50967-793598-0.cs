    using System;
    using System.IO;
    
    class Program
    {
    	static void Main()
    	{
    		String file = "text.txt"; 
    
    		if (File.Exists(file))
    			File.Delete(file);
    
    		FileStream fs = File.Create(file);
    	}
    }
