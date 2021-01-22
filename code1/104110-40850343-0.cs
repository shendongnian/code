    using System;
    using System.Diagnostics;
    using System.Collections;
    using System.Linq;
    					
    public class Program
    {
    	private const int Iterations = 190000;
    	public static void Main()
    	{
    		var sw = new Stopwatch();
    		
    		sw.Start();
    		for (int i = 0; i < Iterations; i++)
    		{
    			IEnumerator enumerator = YieldBreak();
    			while(enumerator.MoveNext())
    			{
    				throw new InvalidOperationException("Should not occur");
    			}			
    		}
    		sw.Stop();
    		
    		Console.WriteLine("Yield break: {0}", sw.Elapsed);
    		
    		GC.Collect();
    		
    		sw.Restart();
    		for (int i = 0; i < Iterations; i++)
    		{
    			IEnumerator enumerator = Enumerable.Empty<object>().GetEnumerator();
    			while(enumerator.MoveNext())
    			{
    				throw new InvalidOperationException("Should not occur");
    			}			
    		}
    		sw.Stop();
    		
    		Console.WriteLine("Enumerable.Empty<T>(): {0}", sw.Elapsed);
    		
    		GC.Collect();
    		
    		sw.Restart();
    		var instance = new EmptyEnumerator();
    		for (int i = 0; i < Iterations; i++)
    		{
    			while(instance.MoveNext())
    			{
    				throw new InvalidOperationException("Should not occur");
    			}			
    		}
    		sw.Stop();
    		
    		Console.WriteLine("EmptyEnumerator instance: {0}", sw.Elapsed);
    	}
    	
    	public static IEnumerator YieldBreak()
    	{
    		yield break;
    	}
    	
    	private class EmptyEnumerator : IEnumerator
    	{
    		//public static readonly EmptyEnumerator Instance = new EmptyEnumerator();
    		
    		public bool MoveNext()
    		{
    			return false;
    		}
    		
    		public void Reset()
    		{
    		}
    		
    		public object Current { get { return null; } }
    	}
    }
