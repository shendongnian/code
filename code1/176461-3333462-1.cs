    using System;
    using System.Diagnostics;
    using System.Threading;
    
    class Program
    {
        static AutoResetEvent _autoResetEvent;
    
        static void Main(string[] args)
        {
            int parentProcessId = int.Parse(args[0]);
    
            _autoResetEvent = new AutoResetEvent(false);
    
            WaitCallback callback = delegate(object processId) { CheckProcess((int)processId); };
            ThreadPool.QueueUserWorkItem(callback, parentProcessId);
    
            _autoResetEvent.WaitOne();
        }
    
        static void CheckProcess(int processId)
        {
            try
            {
                Process process = Process.GetProcessById(processId);
                process.WaitForExit();
                Console.WriteLine("Process [{0}] exited.", processId);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Process [{0}] not running.", processId);
            }
            
            _autoResetEvent.Set();
        }
    }
