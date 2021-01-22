    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    class Program {
    
    	static int [] buffer = new int [1024];
    	const byte mark = 42;
    	const int iterations = 10000;
    
    	static void Main ()
    	{
    		buffer [buffer.Length -1] = mark;
    
    		Console.WriteLine (EqualityComparer<int>.Default.GetType ());
    
    		Console.WriteLine ("Custom:  {0}", Time (CustomIndexOf));
    		Console.WriteLine ("Builtin: {0}", Time (ArrayIndexOf));
    	}
    
    	static TimeSpan Time (Action action)
    	{
    		var watch = new Stopwatch ();
    		watch.Start ();
    		for (int i = 0; i < iterations; i++)
    			action ();
    		watch.Stop ();
    		return watch.Elapsed;
    	}
    
    	static void CustomIndexOf ()
    	{
    		for (int i = 0; i < buffer.Length; i++)
    			if (buffer [i] == mark)
    				break;
    	}
    
    	static void ArrayIndexOf ()
    	{
    		Array.IndexOf (buffer, mark);
    	}
    }
