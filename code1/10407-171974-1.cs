    using System.Diagnostics;
    // Get call stack
    StackTrace stackTrace = new StackTrace();
    // Get calling method name
    Console.WriteLine(stackTrace.GetFrame(1).GetMethod().Name);
