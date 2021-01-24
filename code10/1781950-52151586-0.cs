    using System;
    using System.Linq;
    using System.Threading;
    
    namespace PlayAreaCSCon
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var items = Enumerable.Range(0, 1000);
    			int prodCount = 0;
    
    			foreach(var item in items.AsParallel()
                .AsOrdered()
                .WithMergeOptions(ParallelMergeOptions.NotBuffered)
                .Select((i) =>
    			{
    				Thread.Sleep(i % 100);
    				Interlocked.Increment(ref prodCount);
    				return i;
    			}))
    			{
    				Console.WriteLine(item);
    			}
    			Console.ReadLine();
    		}
    	}
    }
