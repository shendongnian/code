    using (Process process = new Process())
    {
        process.StartInfo.FileName = filename;
        process.StartInfo.Arguments = arguments;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        StringBuilder output = new StringBuilder();
        StringBuilder error = new StringBuilder();
        process.OutputDataReceived += (sender, e) => { output.AppendLine(e.Data); };
        process.ErrorDataReceived += (sender, e) => { error.AppendLine(e.Data); };
        if (process.WaitForExit(timeout))
        {
            // Process completed. Check process.ExitCode here.
        }
        else
        {
            // Timed out waiting for process to terminate.
        }
    }
