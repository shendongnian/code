    using (var process = Process.Start(startInfo))
    {
        var standardOutput = new StringBuilder();
        // read chunk-wise while process is running.
        while (!process.HasExited)
        {
            standardOutput.Append(process.StandardOutput.ReadToEnd());
        }
        // make sure not to miss out on any remaindings.
        standardOutput.Append(process.StandardOutput.ReadToEnd());
        // ...
    }
