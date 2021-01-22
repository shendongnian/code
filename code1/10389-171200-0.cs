    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		public event EventHandler<EventArgs> EventWithDelegate = delegate { };
    		public event EventHandler<EventArgs> EventWithoutDelegate;
    
    		static void Main(string[] args)
    		{
    			//warm up
    			new Program().DoTimings(false);
    			//do it for real
    			new Program().DoTimings(true);
    
    			Console.WriteLine("Done");
    			Console.ReadKey();
    		}
    
    		private void DoTimings(bool output)
    		{
    			const int iterations = 50000000;
    
    			if (output)
    			{
    				Console.WriteLine("For {0} iterations . . .", iterations);
    			}
    
    			//with anonymous delegate attached to avoid null checks
    			var stopWatch = Stopwatch.StartNew();
    
    			for (var i = 0; i < iterations; ++i)
    			{
    				RaiseWithAnonDelegate();
    			}
    
    			stopWatch.Stop();
    
    			if (output)
    			{
    				Console.WriteLine("No null check (empty delegate attached): {0}ms", stopWatch.ElapsedMilliseconds);
    			}
    
    
    			//without any delegates attached (null check required)
    			stopWatch = Stopwatch.StartNew();
    
    			for (var i = 0; i < iterations; ++i)
    			{
    				RaiseWithoutAnonDelegate();
    			}
    
    			stopWatch.Stop();
    
    			if (output)
    			{
    				Console.WriteLine("With null check (no delegates attached): {0}ms", stopWatch.ElapsedMilliseconds);
    			}
    
    
    			//attach delegate
    			EventWithoutDelegate += delegate { };
    
    
    			//with delegate attached (null check still performed)
    			stopWatch = Stopwatch.StartNew();
    
    			for (var i = 0; i < iterations; ++i)
    			{
    				RaiseWithoutAnonDelegate();
    			}
    
    			stopWatch.Stop();
    
    			if (output)
    			{
    				Console.WriteLine("With null check (with delegate attached): {0}ms", stopWatch.ElapsedMilliseconds);
    			}
    		}
    
    		private void RaiseWithAnonDelegate()
    		{
    			EventWithDelegate(this, EventArgs.Empty);
    		}
    
    		private void RaiseWithoutAnonDelegate()
    		{
    			var handler = EventWithoutDelegate;
    
    			if (handler != null)
    			{
    				handler(this, EventArgs.Empty);
    			}
    		}
    	}
    }
