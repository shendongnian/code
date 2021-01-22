        List<Process> processes = new List<Process>();;
        Process process = new Process();
        process.StartInfo = new ProcessStartInfo("app.exe");
        process.StartInfo.WorkingDirectory = "";
        process.StartInfo.Arguments = "some arguments";
        processes.Add(process); 
