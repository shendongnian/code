        Process process2 = new Process();
        process.StartInfo = new ProcessStartInfo("app.exe");
        process.StartInfo.WorkingDirectory = "";
        process.StartInfo.Arguments = "some arguments";
        processes.Add(process2);
