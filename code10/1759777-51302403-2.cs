    process = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = ffmpeg,
            Arguments = args,
            UseShellExecute = false,
            RedirectStandardOutput = true,                    
            CreateNoWindow = false,
            RedirectStandardError = true
        },
        EnableRaisingEvents = true
    };
     
    process.Start();
    
    string processOutput = null;
    while ((processOutput = process.StandardError.ReadLine()) != null)
    {
        // do something with processOutput
        Debug.WriteLine(processOutput);
    }     
