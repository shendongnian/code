    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class Program
    {
    	enum MenuSelection
    	{
    		CreateCustomer = 1,
    		CreateAccount = 2,
    		SetAccountBalance = 3,
    		DisplayAccountBalance = 4,
    		Exit = 5,
    		MaxMenuSelection = 5,
    	}
    		
    	public static void Main()
    	{
    		Enum
    			.GetNames(typeof(MenuSelection))
    			.Select(name => new 
    			{ 
    				name, 
    				index = (int)Enum.Parse(typeof(MenuSelection), name, true) 
    			})
    			.Select(kv => $"[{kv.index}] " + String.Join(" ", SplitByCamelCase(kv.name)))
    			.Select(item => 
    			{
    				Console.WriteLine(item);
    				return true;
    			})
    			.ToList();
    	}
    	
    	public static bool IsLower(char ch) 
    	{
    		return ch >= 'a' && ch <= 'z';
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
    		return new String(str.Skip(Head(str).Length).ToArray());
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
    }
