    using System;
    using System.Collections.Generic;
    
    public class MainClass
    {
    	public static void Main(string[] args)
    	{
    		int[] array = {10, 5, 10, 2, 2, 3, 4, 5, 5, 6, 7, 8, 9, 11, 12, 12};
    		var dict = CountOccurence<int>(array);
    		foreach (var pair in dict)
    			Console.WriteLine("Value {0} occurred {1} times.", pair.Key, pair.Value);
    		
    		string[] array2 = {"10","10", "toto"};
    		var dict2 = CountOccurence<string>(array2);
    		foreach (var pair in dict2)
    			Console.WriteLine("Value {0} occurred {1} times.", pair.Key, pair.Value);
    	}
    
    	public static IDictionary<T, int> CountOccurence<T>(IEnumerable<T> array)
    	{
    		var dict = new Dictionary<T, int>();
    		foreach (var value in array)
    		{
    			if (dict.ContainsKey(value))
    				dict[value]++;
    			else
    				dict[value] = 1;
    		}
    		return dict;
    	}
    }
