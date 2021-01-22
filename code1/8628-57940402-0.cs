    private static int DoProcess(string workingDir, string fileName, string arguments)
    {
        int exitCode;
        using (var process = new Process
        {
            StartInfo =
            {
                WorkingDirectory = workingDir,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false,
                FileName = fileName,
                Arguments = arguments,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            },
            EnableRaisingEvents = true
        })
        {
            using (var outputWaitHandle = new AutoResetEvent(false))
            using (var errorWaitHandle = new AutoResetEvent(false))
            {
                process.OutputDataReceived += (sender, args) =>
                {
                    // ReSharper disable once AccessToDisposedClosure
                    if (args.Data != null) Debug.Log(args.Data);
                    else outputWaitHandle.Set();
                };
                process.ErrorDataReceived += (sender, args) =>
                {
                    // ReSharper disable once AccessToDisposedClosure
                    if (args.Data != null) Debug.LogError(args.Data);
                    else errorWaitHandle.Set();
                };
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                WaitHandle.WaitAll(new WaitHandle[] { outputWaitHandle, errorWaitHandle });
    
                exitCode = process.ExitCode;
            }
        }
        return exitCode;
    }
