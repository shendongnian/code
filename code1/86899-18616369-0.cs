    using (var process = Process.Start(startInfo))
    {
        process.WaitForExit();
        var output = process.StandardOutput.ReadToEnd();
        // ...
    }
