    public static void Monitor()
    { 
        var existingProcesses = Process.GetProcesses();
        bool doProcessing = true;
        while (doProcessing)
        {  
            var currentProcesses = Process.GetProcesses();
            var newProcesses = currentProcesses.Except(existingProcesses);
            int capacity = newProcesses.Count() * 60;
            var builder = new StringBuilder(capacity);
            foreach (var newProcess in newProcesses)
            {
                builder.Append("Launched ProcessName/ID : ");
                builder.Append(newProcess.ProcessName);
                builder.Append("/");
                builder.Append(newProcess.Id);
                builder.AppendLine();
            }
            string newProcessLogEntry = builder.ToString();
            if(!String.IsNullOrEmpty(newProcessLogEntry))
            {
               Log.Info(newProcessLogEntry);
            }
            existingProcesses = currentProcesses;  // Update existing processes, so you don't reprocess previously processed running apps and get "duplicate log entries"
            if (requestToStopMonitoring) // do something to kill this loop gracefully at some point
            {
                doProcessing = false;
                continue;
            }
            Thread.Sleep(5000); // Wait about 5 seconds before iterating again
        }
    }
