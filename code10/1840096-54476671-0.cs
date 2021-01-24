    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var pairs = ((IEnumerable<int>)new[] { 1, 2, 3, 4 }).Pairs();
    		Console.WriteLine(
                string.Join(
                    $",{Environment.NewLine}", 
                    pairs.Select(p => $"{{first:{p.First}, second:{p.Second}}}")));
    	}
    }
    
    public static class Ext
    {
    	public static IEnumerable<Pair<T>> Pairs<T>(
    		this IEnumerable<T> source)
    	{
    		return source.SelectMany(
    			(value, index) => source.Skip(index + 1),
                (first, second) => new Pair<T>(first, second));
    	}
    	
    	public sealed class Pair<T>
    	{
    		internal Pair(T first, T second)
    		{
    		    this.First = first;
    			this.Second = second;
    		}
    		
    		public T First { get; }
    		
    		public T Second { get; }
    	}
    }
