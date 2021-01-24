    var procStartInfo = new ProcessStartInfo
    {
        CreateNoWindow = false,
        WindowStyle = ProcessWindowStyle.Normal,
        FileName = "cmd",
        //Append PATH environment variable bellow if you use this
        Arguments = "/C ewfmgr C: -commit",
        
        //Or use full path to application without changing environment variable
        //Arguments = "/C c:\full\path\to\application\ewfmgr C: -commit",
        UseShellExecute = false,
        RedirectStandardOutput = true,
        RedirectStandardInput = true,
        RedirectStandardError = true
     };
    procStartInfo.EnvironmentVariables["PATH"] += @";c:\full\path\to\application\";
    var process = new Process { StartInfo = procStartInfo, EnableRaisingEvents = true };
    using (StreamWriter writer = new StreamWriter(@"D:\commitFile.txt"))
    {
       process.OutputDataReceived += (sender, e) =>
       {
          writer.WriteLine(e.Data);
       };
       process.ErrorDataReceived+= (sender, e) =>
       {
          writer.WriteLine(e.Data);
       };
       process.Start();
       process.BeginOutputReadLine();
       process.BeginErrorReadLine();
       process.WaitForExit();
    }
