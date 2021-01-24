	process.StartInfo.RedirectStandardOutput = true;
	process.StartInfo.RedirectStandardError = true;
	process.StartInfo.UseShellExecute = false;
	process.StartInfo.CreateNoWindow = true;
	process.OutputDataReceived += Process_OutputDataReceived;
	process.ErrorDataReceived += Process_ErrorDataReceived;
	process.Start();
	process.BeginOutputReadLine();
	process.BeginErrorReadLine();
	process.WaitForExit();
	private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
	{
		if (e.Data == null) return;
		log("ERROR: " + e.Data);
	}
	private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
	{
		if (e.Data == null) return;
		log(e.Data);
	}
