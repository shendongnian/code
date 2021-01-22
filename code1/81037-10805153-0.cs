    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    
    namespace utf16
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			using (StreamReader sr = new StreamReader(args[0], Encoding.UTF8))
    			using (StreamWriter sw = new StreamWriter(args[1], false, Encoding.Unicode))
    			{
    				string line;
    				while ((line = sr.ReadLine()) != null)
    				{
    					sw.WriteLine(line);
    				}
    			}
    		}
    	}
    }
