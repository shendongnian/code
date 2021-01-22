        private string StartProcessAndGetResult(string executableFile, string arguments)
        //NOTE executable file should be passed as string with a full path
        //For example: C:\Windows\Microsoft.NET\Framework\v3.0\Windows Communication Foundation\ServiceModelReg.exe
        //Without """ and @ signs
        {
            var result = String.Empty;
            var workingDirectory = Path.GetDirectoryName(executableFile);
            
            
            var processStartInfo = new ProcessStartInfo(executableFile, arguments)
                                       {
                                           WorkingDirectory = workingDirectory,
                                           UseShellExecute = false,
                                           ErrorDialog = false,
                                           CreateNoWindow = true,
                                           RedirectStandardOutput = true
                                       };
            var process = Process.Start(processStartInfo);
            if (process != null)
            {
                using (var streamReader = process.StandardOutput)
                {
                    result = streamReader.ReadToEnd();
                }
            }
            return result;
        }
