    public void GetProcessOutputWithTimeout(Process process, int timeoutSec, CancellationToken token, out string output, out int exitCode)
	{
		string outputLocal = "";  int localExitCode = -1;
		var task = System.Threading.Tasks.Task.Factory.StartNew(() =>
		{
			outputLocal = process.StandardOutput.ReadToEnd();
			process.WaitForExit();
			localExitCode = process.ExitCode;
		}, token);
		if (task.Wait(timeoutSec, token))
		{
			output = outputLocal;
			exitCode = localExitCode;
		}
		else
		{
			exitCode = -1;
			output = "";
		}
	}
    using (var process = new Process())
	{
		process.StartInfo = ...;
		process.Start();
		string outputUnicode; int exitCode;
		GetProcessOutputWithTimeout(process, PROCESS_TIMEOUT, out outputUnicode, out exitCode);
	}
