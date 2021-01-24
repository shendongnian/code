    // Set working directory and create process
    var workingDirectory = Path.GetFullPath("Scripts");
    var process = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            RedirectStandardInput = true,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            WorkingDirectory = workingDirectory
        }
    };
    process.Start();
    // Pass multiple commands to cmd.exe
    using (var sw = process.StandardInput)
    {
        if (sw.BaseStream.CanWrite)
        {
            // Vital to activate Anaconda
            sw.WriteLine("C:\\PathToAnaconda\\anaconda3\\Scripts\\activate.bat");
            // Activate your environment
            sw.WriteLine("activate your-environment");
            // Any other commands you want to run
            sw.WriteLine("set KERAS_BACKEND=tensorflow");
            // run your script. You can also pass in arguments
            sw.WriteLine("python YourScript.py");
        }
    }
    
    // read multiple output lines
    while (!process.StandardOutput.EndOfStream)
    {
        var line = process.StandardOutput.ReadLine();
        Console.WriteLine(line);
    }
