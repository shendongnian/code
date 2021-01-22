	private static void CaptureConsoleAppOutput(string exeName, string arguments, int timeoutMilliseconds, out int exitCode, out string output)
	{
		using (Process process = new Process())
		{
			process.StartInfo.FileName = exeName;
			process.StartInfo.Arguments = arguments;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.CreateNoWindow = true;
			process.Start();
			output = process.StandardOutput.ReadToEnd();
			bool exited = process.WaitForExit(timeoutMilliseconds);
			if (exited)
			{
				exitCode = process.ExitCode;
			}
			else
			{
				exitCode = -1;
			}
		}
	}
