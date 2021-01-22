    public static void Monitor()
    { 
        var existingProcesses = Process.GetProcesses();
        while (true)
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
        }
    }
