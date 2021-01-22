		private static string ExecCommand(string filename, string arguments)
		{
			Process process = new Process();
			ProcessStartInfo psi = new ProcessStartInfo(filename);
			psi.Arguments = arguments;
			psi.CreateNoWindow = true;
			psi.RedirectStandardOutput = true;
			psi.RedirectStandardError = true;
			psi.UseShellExecute = false;
			process.StartInfo = psi;
			StringBuilder output = new StringBuilder();
			process.OutputDataReceived += (sender, e) => { output.AppendLine(e.Data); };
			process.ErrorDataReceived += (sender, e) => { output.AppendLine(e.Data); };
			
			// run the process
			process.Start();
			
			// start reading output to events
			process.BeginOutputReadLine();
			process.BeginErrorReadLine();
			// wait for process to exit
			process.WaitForExit();
			if (process.ExitCode != 0)
				throw new Exception("Command " + psi.FileName + " returned exit code " + process.ExitCode);
			return output.ToString();
		}
