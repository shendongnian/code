    using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
    using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
    {
        using (process = new Process())
        {
            // preparing ProcessStartInfo
    
            try
            {
                this.Process.OutputDataReceived += (sender, e) =>
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
                this.Process.ErrorDataReceived += (sender, e) =>
                    {
                        if (e.Data == null)
                        {
                            errorWaitHandle.Set();
                        }
                        else
                        {
                            outputBuilder.AppendLine(e.Data);
                        }
                    };
    
                this.Process.Start();
    
                this.Process.BeginOutputReadLine();
                this.Process.BeginErrorReadLine();
    
                if (this.Process.WaitForExit(timeout))
                {
                    exitCode = this.Process.ExitCode;
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
