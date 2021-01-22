    using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
    using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
    {
        using (Process process = new Process())
        {
            // preparing ProcessStartInfo
    
            try
            {
                process.OutputDataReceived += (sender, e) =>
                    {
                        if (e.Data == null)
                        {
                            outputWaitHandle.Set();
                        }
                        else
                        {
                            outputBuilder.AppendLine(e.Data);
                        }
                    };
                process.ErrorDataReceived += (sender, e) =>
                    {
                        if (e.Data == null)
                        {
                            errorWaitHandle.Set();
                        }
                        else
                        {
                            errorBuilder.AppendLine(e.Data);
                        }
                    };
    
                process.Start();
    
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
    
                if (process.WaitForExit(timeout))
                {
                    exitCode = process.ExitCode;
                }
                else
                {
                    // timed out
                }
    
                output = outputBuilder.ToString();
            }
            finally
            {
                outputWaitHandle.WaitOne(timeout);
                errorWaitHandle.WaitOne(timeout);
            }
        }
    }
