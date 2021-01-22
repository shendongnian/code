    using System.Collections.Generic;
    using System;
    
    public class Test
    {
        private Int32 age = 42;
    	 
    	static public void Main()
        {
    	   (new Test()).TestMethod();
    	}
    	
    	public void TestMethod()
    	{
    	    Dictionary<Int32, string> myDict = new Dictionary<Int32, string>();
    		
            myDict[age] = age.ToString();
    		
    	    foreach(KeyValuePair<Int32, string> pair in myDict)
    	    {
    	        Console.WriteLine("{0} : {1}", pair.Key, pair.Value);
    	    	++age;
    	        Console.WriteLine("{0} : {1}", pair.Key, pair.Value);
    	    	myDict[pair.Key] = "new";
                Console.WriteLine("Changed!");
    	    }
        }	
    }
