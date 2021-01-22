    using System;
    class Test {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler (OnProcessExit); 
            // Do something here
        }
        static void OnProcessExit (object sender, EventArgs e)
        {
            Console.WriteLine ("I'm out of here");
        }
    }
