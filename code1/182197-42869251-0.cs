    internal static int RunProcess(string fileName, string args, string workingDir)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = fileName,
            Arguments = args,
            UseShellExecute = false,
            RedirectStandardError = true,
            RedirectStandardOutput = true,
            CreateNoWindow = true,
            WorkingDirectory = workingDir
        };
        using (var process = Process.Start(startInfo))
        {
            if (process == null)
            {
                throw new Exception($"Failed to start {startInfo.FileName}");
            }
            process.OutputDataReceived += (s, e) => e.Data.Log();
            process.ErrorDataReceived += (s, e) =>
                {
                    if (!string.IsNullOrWhiteSpace(e.Data)) { new Exception(e.Data).Log(); }
                };
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            return process.ExitCode;
        }
    }
