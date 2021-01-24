    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    public class Test
    {
    	public static void Main(string[] args)
    	{
    		Dictionary<string, Action> dict = new Dictionary<string, Action>();
    	   dict.Add("Do1", ActionDo1);	
    		dict.Add("Do2", ActionDo1);	
    		
    		dict["Do1"]();
    	}
    	
    	public static void ActionDo1()
    	{
    		Console.WriteLine("The Do1 is called");
    	}
    	
    	public static void ActionDo2()
    	{
    		Console.WriteLine("The Do2 is called");
    	}
    
    	
    }
