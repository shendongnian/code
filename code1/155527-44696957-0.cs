    using System;
    using System.IO;
    using System.Timers;
    System.Timers.Timer t = new System.Timers.Timer() {
        Interval = 1000,
        AutoReset = false
    };
    
    t.Elapsed  += delegate(System.Object o, System.Timers.ElapsedEventArgs e)
        { Console.WriteLine("Hell");}; 
    t.Start();
