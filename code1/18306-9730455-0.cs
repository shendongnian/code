	StringBuilder outputBuilder;
	ProcessStartInfo processStartInfo;
	Process process;
	outputBuilder = new StringBuilder();
	processStartInfo = new ProcessStartInfo();
	processStartInfo.CreateNoWindow = true;
	processStartInfo.RedirectStandardOutput = true;
	processStartInfo.RedirectStandardInput = true;
	processStartInfo.UseShellExecute = false;
	processStartInfo.Arguments = "<insert command line arguments here>";
	processStartInfo.FileName = "<insert tool path here>";
	process = new Process();
	process.StartInfo = processStartInfo;
	// enable raising events because Process does not raise events by default
	process.EnableRaisingEvents = true;
	// attach the event handler for OutputDataReceived before starting the process
	process.OutputDataReceived += new DataReceivedEventHandler
	(
		delegate(object sender, DataReceivedEventArgs e)
		{
			// append the new data to the data already read-in
			outputBuilder.Append(e.Data);
		}
	);
	// start the process
	// then begin asynchronously reading the output
	// then wait for the process to exit
	// then cancel asynchronously reading the output
	process.Start();
	process.BeginOutputReadLine();
	process.WaitForExit();
	process.CancelOutputRead();
	// use the output
	string output = outputBuilder.ToString();
