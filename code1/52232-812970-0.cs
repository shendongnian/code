	using System;
	namespace ConsoleApplication4
	{
		class Program
		{
			static void Main(string[] args)
			{
				SomeCaller callerOne;
				YetAnotherCaller callerTwo;
					
				callerOne = new SomeCaller(SomeMethod);
				LogCallDuration(callerOne, new object[] { 15 });
				callerOne = new SomeCaller(SomeOtherMethod);
				LogCallDuration(callerOne, new object[] { 22 });
				callerTwo = new YetAnotherCaller(YetAnotherMethod);
				LogCallDuration(callerTwo, null);
				Console.ReadKey();
			}
			#region "Supporting Methods/Delegates"
			delegate void SomeCaller(int someArg);
			delegate void YetAnotherCaller();
			static void LogCallDuration(Delegate targetMethod, object[] args)
			{
				DateTime start = DateTime.UtcNow;
				targetMethod.DynamicInvoke(args);
				DateTime stop = DateTime.UtcNow;
				TimeSpan duration = stop - start;
				Console.WriteLine(string.Format("Method '{0}' took {1}ms to complete", targetMethod.Method.Name, duration.Milliseconds));
			}
			#endregion "Supporting Methods/Delegates"
			#region "Target methods, these don't have to be in your code"
			static void SomeMethod(int someArg)
			{
				// Do something that takes a little time
				System.Threading.Thread.Sleep(1 + someArg);
			}
			static void SomeOtherMethod(int someArg)
			{
				// Do something that takes a little time
				System.Threading.Thread.Sleep(320 - someArg);
			}
			static void YetAnotherMethod()
			{
				// Do something that takes a little time
				System.Threading.Thread.Sleep(150);
			}
			#endregion "Target methods"
		}
	}
