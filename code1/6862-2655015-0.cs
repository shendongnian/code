    using System;
    using System.Diagnostics;
    
    class app
    {
       static void Main ()
       {
           var pc = new PerformanceCounter ("Mono Memory", "Total Physical Memory");
           Console.WriteLine ("Physical RAM (bytes): {0}", pc.RawValue);
       }
    }
