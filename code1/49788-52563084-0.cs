    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		Console
    			.WriteLine(
    				SeparateByCamelCase("TestString") == "Test String" // True
    			);
    	}
    	
    	public static string SeparateByCamelCase(string str)
    	{
    		return String.Join(" ", SplitByCamelCase(str));
    	}
    	
    	public static IEnumerable<string> SplitByCamelCase(string str) 
    	{
    		if (str.Length == 0) 
    			return new List<string>();
    		
    		return 
    			new List<string> 
    			{ 
    				Head(str) 
    			}
    			.Concat(
    				SplitByCamelCase(
    					Tail(str)
    				)
    			);
    	}
    		
    	public static string Head(string str)
    	{
    		return new String(
    					str
    						.Take(1)
    						.Concat(
    							str
    								.Skip(1)
    								.TakeWhile(IsLower)
    						)
    						.ToArray()
    				);
    	}
    	
    	public static string Tail(string str)
    	{
    		return new String(
    					str
    						.Skip(
    							Head(str).Length
    						)
    						.ToArray()
    				);
    	}
    	
    	public static bool IsLower(char ch) 
    	{
    		return ch >= 'a' && ch <= 'z';
    	}
    }
