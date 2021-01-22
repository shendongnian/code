    using System;
    using System.Diagnostics;
    using System.Threading;
    
    class Program
    {
        static AutoResetEvent _autoResetEvent;
    
        static void Main(string[] args)
        {
            int parentProcessId = int.Parse(args[0]);
            Process process = Process.GetProcessById(parentProcessId);
            process.EnableRaisingEvents = true;
            process.Exited += new EventHandler(process_Exited);
    
            _autoResetEvent = new AutoResetEvent(false);
            _autoResetEvent.WaitOne();
        }
    
        static void process_Exited(object sender, EventArgs e)
        {
            Console.WriteLine("Process exit event triggered.");
            _autoResetEvent.Set();
        }
    }
