    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		
    		MyProgram p = new MyProgram();
    		
    		p.Add("First" , 5);
    		p.Add("Second" , 8);
    		p.Add("Third" , 9);
    		p.Add("First" , 6);
    		p.Add("First" , 7);
    		
    		p.PrintDictionary();
    	}
    }
    
    
    public class MyProgram
    {
    	private Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();
    	
    	public void Add(string key, int value)
    	{
    		if (dict.ContainsKey(key))
    		{
    			dict[key].Add(value);
    		}
    		else
    		{
    			dict.Add(key, new List<int>() {value});
    		}
    	}
    	
    	public void PrintDictionary()
    	{
    		foreach(var keyValue in dict)
    		{
    			Console.WriteLine("Key : " + keyValue.Key);
    			
    			foreach(var val in keyValue.Value)
    			{
    				Console.WriteLine(string.Format("\t Value : {0}", val));
    			}
    		}
    	}
    }
