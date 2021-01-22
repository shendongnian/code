	using System.Diagnostics;
	// get call stack
	StackTrace stackTrace = new StackTrace();
	// get calling method name
	Console.WriteLine(stackTrace.GetFrame(1).GetMethod().Name);
