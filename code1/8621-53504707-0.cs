    using (Process process = new Process())
    {
        process.StartInfo.FileName = filename;
        process.StartInfo.Arguments = arguments;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
    
        process.Start();
        var tStandardOutput = process.StandardOutput.ReadToEndAsync();
        var tStandardError = process.StandardError.ReadToEndAsync();
        if (process.WaitForExit(timeout))
        {
            string output = await tStandardOutput;
            string errors = await tStandardError;
            // Process completed. Check process.ExitCode here.
        }
        else
        {
            // Timed out.
        }
    }
