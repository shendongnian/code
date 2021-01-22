    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication
    {
    	class Program
    	{
    		static bool generateFrame;
    
    		static void Main(string[] args)
    		{
    			Stopwatch sw;
    
    			// warm up
    			for (int i = 0; i < 100000; i++)
    			{
    				CallA();
    			}
    
    			// call 100K times; no stackframes
    			sw = Stopwatch.StartNew();
    			for (int i = 0; i < 100000; i++)
    			{
    				CallA();
    			}
    			sw.Stop();
    			Console.WriteLine("Don't generate 100K frames: {0}ms"
                                     , sw.ElapsedMilliseconds);
    
    			// call 100K times; generate stackframes
    			generateFrame = true;
    			sw = Stopwatch.StartNew();
    			for (int i = 0; i < 100000; i++)
    			{
    				CallA();
    			}
    			Console.WriteLine("Generate 100K frames: {0}ms"
                               , sw.ElapsedMilliseconds);
    
    			Console.ReadKey();
    		}
    
    		private static void CallA()
    		{
    			CallB();
    		}
    
    		private static void CallB()
    		{
    			CallC();
    		}
    
    		private static void CallC()
    		{
    			if (generateFrame)
    			{
    				StackFrame stackFrame = new StackFrame(1);
    			}
    		}
    	}
    }
