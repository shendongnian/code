    using System.Diagnostics;
    
    Process process = new Process();
    
    void LaunchProcess()
    {
    	process.EnableRaisingEvents = true;
    	process.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_OutputDataReceived);
    	process.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_ErrorDataReceived);
    	process.Exited += new System.EventHandler(process_Exited);
    
    	process.StartInfo.FileName = "some.exe";
    	process.StartInfo.Arguments = "param1 param2"
    	process.StartInfo.UseShellExecute = false;
    	process.StartInfo.RedirectStandardError = true;
    	process.StartInfo.RedirectStandardOutput = true;
    
    	process.Start();
    	process.BeginErrorReadLine();
    	process.BeginOutputReadLine();			
    	
    	//below line is optional if we want a blocking call
    	//process.WaitForExit();
    }
    
    void process_Exited(object sender, EventArgs e)
    {
    	Console.WriteLine(string.Format("process exited with code {0}\n", process.ExitCode.ToString()));
    }
    
    void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
    	Console.WriteLine(e.Data + "\n");
    }
    
    void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
    	Console.WriteLine(e.Data + "\n");
    }
