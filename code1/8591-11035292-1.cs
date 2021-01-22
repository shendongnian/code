    public static string GGSCIShell(string Path, string Command)
    {
        using (Process process = new Process())
        {
            process.StartInfo.WorkingDirectory = Path;
            process.StartInfo.FileName = Path + @"\ggsci.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.UseShellExecute = false;
            StringBuilder output = new StringBuilder();
            process.OutputDataReceived += (sender, e) =>
            {
                if (e.Data != null)
                {
                    output.AppendLine(e.Data);
                }
            };
            process.Start();
            process.StandardInput.WriteLine(Command);
            process.BeginOutputReadLine();
            int timeoutParts = 10;
            int timeoutPart = (int)TIMEOUT / timeoutParts;
            do
            {
                Thread.Sleep(500);//sometimes halv scond is enough to empty output buff (therefore "exit" will be accepted without "timeoutPart" waiting)
                process.StandardInput.WriteLine("exit");
                timeoutParts--;
            }
            while (!process.WaitForExit(timeoutPart) && timeoutParts > 0);
            if (timeoutParts <= 0)
            {
                output.AppendLine("------ GGSCIShell TIMEOUT: " + TIMEOUT + "ms ------");
            }
            string result = output.ToString();
            return result;
        }
    }
