    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    					
    public class Program
    {
    	public static void Main()
    	{
    		var list = new List<MainClass>{new A{PropA = "a", MainProp = "mainA"}, new B{PropB = "b", MainProp = "mainB"}};
    		string output = JsonConvert.SerializeObject(list);
    		
    		Console.WriteLine(output);
    		
    	}
    	
    	
    	public class MainClass {
    		public string MainProp { get; set; }	
    	}
    	
    	public class A : MainClass {
    		
    		public string PropA { get; set; }
    	}
    	
    	public class B : MainClass {
    		
    		public string PropB { get; set; }
    	}
    }
