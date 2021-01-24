    Process process = new Process();
    process.StartInfo.FileName = @"C:\Temp\batch.bat";
    process.StartInfo.RedirectStandardOutput = true;
    process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
    {
    	// Prepend line numbers to each line of the output.
    	if (!String.IsNullOrEmpty(e.Data))
    	{
    		Console.WriteLine(e.Data);// to see what happens
    		// parse e.Data here
    	}
    });
    
    process.Start();
    
    // Asynchronously read the standard output of the spawned process. 
    // This raises OutputDataReceived events for each line of output.
    process.BeginOutputReadLine();
    
    process.WaitForExit();
    process.Close();
