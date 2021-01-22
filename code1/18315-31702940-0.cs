    Process process = new Process();
    StringBuilder outputStringBuilder = new StringBuilder();
    try
    {
	process.StartInfo.FileName = exeFileName;
	process.StartInfo.WorkingDirectory = args.ExeDirectory;
	process.StartInfo.Arguments = args;
	process.StartInfo.RedirectStandardError = true;
	process.StartInfo.RedirectStandardOutput = true;
	process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
	process.StartInfo.CreateNoWindow = true;
	process.StartInfo.UseShellExecute = false;
	process.EnableRaisingEvents = false;
	process.OutputDataReceived += (sender, eventArgs) => outputStringBuilder.AppendLine(eventArgs.Data);
	process.ErrorDataReceived += (sender, eventArgs) => outputStringBuilder.AppendLine(eventArgs.Data);
	process.Start();
	process.BeginOutputReadLine();
	process.BeginErrorReadLine();
	var processExited = process.WaitForExit(PROCESS_TIMEOUT);
	if (processExited == false) // we timed out...
	{
	    process.Kill();
	    throw new Exception("ERROR: Process took too long to finish");
	}
	else if (process.ExitCode != 0)
	{
	    var output = outputStringBuilder.ToString();
	    var prefixMessage = "";
	    throw new Exception("Process exited with non-zero exit code of: " + process.ExitCode + Environment.NewLine + 
		"Output from wkhtmltopdf: " + outputStringBuilder.ToString());
	}
    }
    finally
    {                
	process.Close();
    }
