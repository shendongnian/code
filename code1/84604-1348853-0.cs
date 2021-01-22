	using System;
	using System.Diagnostics;
	using System.Reflection;
	namespace ConsoleApplication
	{
		class Program
		{
			static bool traceCalls;
			static void Main(string[] args)
			{
				Stopwatch sw;
				// warm up
				for (int i = 0; i < 100000; i++)
				{
					TraceCall();
				}
				// call 100K times, tracing *disabled*, passing method name
				sw = Stopwatch.StartNew();
				traceCalls = false;
				for (int i = 0; i < 100000; i++)
				{
					TraceCall(MethodBase.GetCurrentMethod().Name);
				}
				sw.Stop();
				Console.WriteLine("Tracing Disabled, passing Method Name: {0}ms"
								 , sw.ElapsedMilliseconds);
				// call 100K times, tracing *enabled*, passing method name
				sw = Stopwatch.StartNew();
				traceCalls = true;
				for (int i = 0; i < 100000; i++)
				{
					TraceCall(MethodBase.GetCurrentMethod().Name);
				}
				sw.Stop();
				Console.WriteLine("Tracing Enabled, passing Method Name: {0}ms"
								 , sw.ElapsedMilliseconds);
				// call 100K times, tracing *disabled*, determining method name
				sw = Stopwatch.StartNew();
				traceCalls = false;
				for (int i = 0; i < 100000; i++)
				{
					TraceCall();
				}
				Console.WriteLine("Tracing Disabled, looking up Method Name: {0}ms"
						   , sw.ElapsedMilliseconds);
				// call 100K times, tracing *enabled*, determining method name
				sw = Stopwatch.StartNew();
				traceCalls = true;
				for (int i = 0; i < 100000; i++)
				{
					TraceCall();
				}
				Console.WriteLine("Tracing Enabled, looking up Method Name: {0}ms"
						   , sw.ElapsedMilliseconds);
				Console.ReadKey();
			}
			private static void TraceCall()
			{
				if (traceCalls)
				{
					StackFrame stackFrame = new StackFrame(1);
					TraceCall(stackFrame.GetMethod().Name);
				}
			}
			private static void TraceCall(MethodBase method)
			{
				if (traceCalls)
				{
					TraceCall(method.Name);
				}
			}
			private static void TraceCall(string methodName)
			{
				// Write to log
			}
		}
	}
