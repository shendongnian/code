		static int RunProgram(string exe, params string[] args)
		{
			ManualResetEvent mreProcessExit = new ManualResetEvent(false);
			ManualResetEvent mreOutputDone = new ManualResetEvent(false);
			ManualResetEvent mreErrorDone = new ManualResetEvent(false);
			ProcessStartInfo psi = new ProcessStartInfo(exe, String.Join(" ", args));
			psi.WorkingDirectory = Environment.CurrentDirectory;
			psi.RedirectStandardError = true;
			psi.RedirectStandardOutput = true;
			psi.CreateNoWindow = true;
			psi.UseShellExecute = false;
			psi.ErrorDialog = true;
			Process process = new Process();
			process.StartInfo = psi;
			process.Exited += delegate(object o, EventArgs e)
			{
				Console.WriteLine("Exited.");
				mreProcessExit.Set();
			};
			process.OutputDataReceived += delegate(object o, DataReceivedEventArgs e) 
			{
				if( e.Data != null )
					Console.WriteLine("Output: {0}", e.Data); 
				else
					mreOutputDone.Set(); 
			};
			process.ErrorDataReceived += delegate(object o, DataReceivedEventArgs e)
			{
				if (e.Data != null)
					Console.Error.WriteLine("Error: {0}", e.Data);
				else
					mreErrorDone.Set();
			};
			process.EnableRaisingEvents = true;
			Console.WriteLine("Start: {0}", process.StartInfo.FileName); 
			process.Start();
			process.BeginErrorReadLine();
			process.BeginOutputReadLine();
			if (process.HasExited) 
				mreProcessExit.Set();
			while(!WaitHandle.WaitAll(new WaitHandle[] { mreErrorDone, mreOutputDone, mreProcessExit }, 100))
				continue;
			return process.ExitCode;
		}
