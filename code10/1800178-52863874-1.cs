    using System;
    using System.Collections.Generic;
    using System.Linq;
    	
    static class Extensions
    {
    	public static IEnumerable<T> Prepend<T>(
    		this IEnumerable<T> items,
    		T first)
    	{
    		yield return first;
    		foreach(T item in items)
    			yield return item;
    	}
    	public static IEnumerable<IEnumerable<T>> Combinations<T>(
    		this IEnumerable<T> items)
    	{
    		if (!items.Any())
    			yield return items;
            else
            {
              var head = items.First();
              var tail = items.Skip(1);
      		  foreach(var sequence in tail.Combinations()) 
    		  {
    			yield return sequence; // Without first
    			yield return sequence.Prepend(head);
    		  }
           }
    	}
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		var items = new [] { 10, 20, 30 };
    		foreach(var sequence in items.Combinations())
    			Console.WriteLine($"({string.Join(",", sequence)})");
    	}
    }
