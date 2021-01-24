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
    	
    	public static string Head(string str)
    	{
    		return new String(
    				str
    					.Take(1)
    					.Concat(
    						str
    							.Skip(1)
    							.TakeWhile(ch => ch >= 'a' && ch <= 'z')
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
    		if (str.Length == 0) return new List<string>();
    		return (new List<string> { Head(str) }).Concat(SplitByCamelCase(Tail(str)));
    	}
    	
    	public static List<int> GetInts()
    	{
    		return Enum.GetNames(typeof(MenuSelection))
    			.Select(x => Enum.Parse(typeof(MenuSelection), x, true))
    			.Cast<int>()
    			.ToList();
    	}
    	
    	public static void Main()
    	{
    		Enum
    			.GetNames(typeof(MenuSelection))
    			.Zip(GetInts(), (key, val) => new {val, key})
    			.Select(kv => $"[{kv.val}] " + String.Join(" ", SplitByCamelCase(kv.key)))
    			.Select(x => {
    				Console.WriteLine(x);
    				return true;
    			})
    			.ToList();
    	}
    }
