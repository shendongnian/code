        string fileName = Path.Combine(Environment.SystemDirectory, "wbem", "wmic.exe");
        string arguments = @"cpu get NumberOfCores";
        Process process = new Process
        {
            StartInfo =
            {
                FileName = fileName,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            }
        };
        process.Start();
        StreamReader output = process.StandardOutput;
        Console.WriteLine(output.ReadToEnd());
        
        process.WaitForExit();
        int exitCode = process.ExitCode;
        process.Close();
        
            
