    public class Runner
    {
        public void Run(string executable, object processExitHandler)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                var p = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = executable
                    }
                };
                p.Start();
                while (!p.HasExited)
                {
                    Thread.Sleep(100);
                }
    
                state
                    .GetType()
                    .InvokeMember(
                        "call", 
                        BindingFlags.InvokeMethod, 
                        null, 
                        state, 
                        new object[] { null, p.ExitCode }
                    );
            }, processExitHandler);
        }
    }
