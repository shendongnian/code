    // Setup ProcessStartInfo
    var processInfo = new ProcessStartInfo();
    processInfo.FileName = Environment.ExpandEnvironmentVariables("%windir%\system32\inetsrv\appcmd.exe");
    processInfo.Arguments = "list site";
    processInfo.RedirectStandardOutput = true;
    processInfo.UseShellExecute = false;
    // Start the process
    var process = new Process();
    process.StartInfo = processInfo; 
    process.Start(processInfo);
 
    // Capture the output and wait for exit
    var output = process.StandardOutput.ReadToEnd();
    process.WaitForExit();
    // Parse the output
    var ports = Regex.Matches(output, ":([0-9]+):");
    foreach (Match port in ports)
    {
        // TODO: Do something with the ports here
        Console.WriteLine(port.Groups[1].Captures[0].Value);
    }
    
    
    
