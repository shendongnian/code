    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var r = Enumerable.Range(1, 20);
    		foreach (int i in r.AllButLast(3))
    			Console.WriteLine(i);		
    	}	
    }
    
    
    public static class LinqExt {
    	
    	public static IEnumerable<T> AllButLast<T>(this IEnumerable<T> enumerable, int n = 1)
    	{
    		var queue = new Queue<T>(n);
    		IEnumerator<T> enumerator = enumerable.GetEnumerator();
    		
    		for(int i=0; i<n && enumerator.MoveNext(); i++)
    			queue.Enqueue(enumerator.Current);
    	
    		while (enumerator.MoveNext())
    		{
    		    queue.Enqueue(enumerator.Current);
    			yield return queue.Dequeue();
    	
    		}
    	}	
    }
