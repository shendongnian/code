    Process vbsProcess = new Process();
    vbsProcess.StartInfo.FileName = "yourscript.vbs";
    vbsProcess.StartInfo.UseShellExecute = false;
    vbsProcess.StartInfo.RedirectStandardOutput = true;
    vbsProcess.OutputDataReceived += new DataReceivedEventHandler(YourOutputHandler);
    vbsProcess.Start();
    vbsProcess.WaitForExit();
