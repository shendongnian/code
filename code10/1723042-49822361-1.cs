    using System;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		int[] src = {4, 5, 6};
    		List<int> copy = Convert<List<int>>(src);
    		Stack<int> copy1 = Convert<Stack<int>>(src);
    		Queue<int> copy2 = Convert<Queue<int>>(src);
    		
    		Console.WriteLine(string.Join(",",copy));
    		Console.WriteLine(string.Join(",",copy1));
         	Console.WriteLine(string.Join(",",copy2));    
    	}
    	
    	public static T Convert<T>(int[] src) where T : new()
    	{
    		var obj = Activator.CreateInstance(typeof(T), src);
    		return (T)obj;
    	}
    }
