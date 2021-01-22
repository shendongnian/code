    public class ProcessManager:IDisposable
    {
        List<Process> processes=new List<Process>();
        public Process Start(ProcessStartInfo info)
        {
            var newProcess = Process.Start(info);
            processes.Add(newProcess);
            newProcess.Exited += (sender, e) => processes.Remove(newProcess);
            return newProcess;
        }
        ~ProcessManager()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            foreach (var process in processes)
            {
                try
                {
                    if (!process.HasExited)
                        process.Kill();
                }
                catch{}                    
            }
        }
    }
