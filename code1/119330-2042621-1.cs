    using (Process process = new Process())
    {
        process.StartInfo = startInfo;
        process.Start();
        // only if you need the output for debugging
        //string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        return process.ExitCode;
    }
