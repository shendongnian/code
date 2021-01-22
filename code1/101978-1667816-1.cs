    using System;
    using System.Diagnostics;
    
    public static void Main(string[] args)
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.WriteLine("Program Started - " + DateTime.Now.ToString());Trace.WriteLine("");
    
        //Call into a separate class or method for the actual program logic
        DoSomething();
    
        Trace.WriteLine("");Trace.WriteLine("Program Finished - " + DateTime.Now.ToString());
    
        Console.Write("Press a key to exit...");
        Console.ReadKey(true);
        Console.WriteLine();
    }
    
