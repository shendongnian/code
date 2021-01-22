    using System;
    
    public class MyClass
    {
        public static void CtrlCHandler(object sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("Parent killed by CTRL+C.");
        }
        public static void Main()
        {
            Console.CancelKeyPress += CtrlCHandler;
            Console.WriteLine("Parent start.");
            System.Diagnostics.Process child = new System.Diagnostics.Process();
            child.StartInfo.UseShellExecute = false;
            child.StartInfo.FileName = "child.exe";
            child.Start();
            child.WaitForExit();
            Console.WriteLine("Parent finish.");
        }
    }
