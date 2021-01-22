    static void RunCommands(List<string> cmds, string workingDirectory = "")
    {
    	var process = new Process();
    	var psi = new ProcessStartInfo();
    	psi.FileName = "cmd.exe";
    	psi.RedirectStandardInput = true;
    	psi.RedirectStandardOutput = true;
    	psi.RedirectStandardError = true;
    	psi.UseShellExecute = false;
    	psi.WorkingDirectory = workingDirectory;
    	process.StartInfo = psi;
    	process.Start();
    	process.OutputDataReceived += (sender, e) => { Console.WriteLine(e.Data); };
    	process.ErrorDataReceived += (sender, e) => { Console.WriteLine(e.Data); };
    	process.BeginOutputReadLine();
    	process.BeginErrorReadLine();
    	using (StreamWriter sw = process.StandardInput)
    	{
    		foreach (var cmd in cmds)
    		{
    			sw.WriteLine (cmd);
    		}
    	}
    	process.WaitForExit();
    }
