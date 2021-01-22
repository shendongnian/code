    var info = new ProcessStartInfo(path)
    {
    	RedirectStandardError = true,
    	RedirectStandardOutput = true,
    	UseShellExecute = false,
    	Verb = "runas",
    };
    
    var process = new Process
    {
    	EnableRaisingEvents = true,
    	StartInfo = info
    };
    
    Action<object, DataReceivedEventArgs> actionWrite = (sender, e) =>
    {
    	Console.WriteLine(e.Data);
    };
    
    process.ErrorDataReceived += (sender, e) => actionWrite(sender, e);
    process.OutputDataReceived += (sender, e) => actionWrite(sender, e);
    
    process.Start();
    process.BeginOutputReadLine();
    process.BeginErrorReadLine();
    process.WaitForExit();
