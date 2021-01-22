    public struct ProcessResult
    {
        public string stdout;
        public string stderr;
        public bool hasTimedOut;
        private int? exitCode;
        public ProcessResult(bool hasTimedOut = true)
        {
            this.hasTimedOut = hasTimedOut;
            stdout = null;
            stderr = null;
            exitCode = null;
        }
        public int ExitCode
        {
            get 
            {
                if (hasTimedOut)
                    throw new InvalidOperationException(
                        "There was no exit code - process has timed out.");
                return (int)exitCode;
            }
            set
            {
                exitCode = value;
            }
        }
    }
    
    public class ProcessNoBS
    {
        public static ProcessResult Start(string filename, string arguments,
            string workingDir = null, int timeoutInMs = 5000,
            bool combineStdoutAndStderr = false)
        {
            using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
            using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
            {
                using (var process = new Process())
                {
                    var info = new ProcessStartInfo();
                    info.CreateNoWindow = true;
                    info.FileName = filename;
                    info.Arguments = arguments;
                    info.UseShellExecute = false;
                    info.RedirectStandardOutput = true;
                    info.RedirectStandardError = true;
                    if (workingDir != null)
                        info.WorkingDirectory = workingDir;
                    process.StartInfo = info;
                    StringBuilder stdout = new StringBuilder();
                    StringBuilder stderr = combineStdoutAndStderr
                        ? stdout : new StringBuilder();
                    var result = new ProcessResult();
                    
                    try
                    {
                        process.OutputDataReceived += (sender, e) =>
                        {
                            if (e.Data == null)
                                outputWaitHandle.Set();
                            else
                                stdout.AppendLine(e.Data);
                        };
                        process.ErrorDataReceived += (sender, e) =>
                        {
                            if (e.Data == null)
                                errorWaitHandle.Set();
                            else
                                stderr.AppendLine(e.Data);
                        };
                        process.Start();
                        process.BeginOutputReadLine();
                        process.BeginErrorReadLine();
                        if (process.WaitForExit(timeoutInMs))
                            result.ExitCode = process.ExitCode;
                        // else process has timed out 
                        // but that's already default ProcessResult
                        result.stdout = stdout.ToString();
                        if (combineStdoutAndStderr)
                            result.stderr = null;
                        else
                            result.stderr = stderr.ToString();
                        return result;
                    }
                    finally
                    {
                        outputWaitHandle.WaitOne(timeoutInMs);
                        errorWaitHandle.WaitOne(timeoutInMs);
                    }
                }
            }
        }
    }
