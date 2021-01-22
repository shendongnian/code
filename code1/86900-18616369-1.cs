    using (var process = Process.Start(startInfo))
    {
        var standardOutput = new StringBuilder();
        while (!process.HasExited)
        {
            standardOutput.Append(process.StandardOutput.ReadToEnd());
        }
        process.WaitForExit();
        standardOutput.Append(process.StandardOutput.ReadToEnd());
        // ...
    }
