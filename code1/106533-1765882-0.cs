        public static void Run(string fileName, string arguments, out string standardOutput, out string standardError, out int exitCode)
        {
            Process fileProcess = new Process();
            fileProcess.StartInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
            };
            bool started = fileProcess.Start();
            if (started)
            {
                fileProcess.WaitForExit();
            }
            else
            {
                throw new Exception("Couldn't start");
            }
            standardOutput = fileProcess.StandardOutput.ReadToEnd();
            standardError = fileProcess.StandardError.ReadToEnd();
            exitCode = fileProcess.ExitCode;
        }
