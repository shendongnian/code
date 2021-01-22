        class MyProcessStarter
        {
            private ProcessStartInfo _startInfo = new ProcessStartInfo();
            public MyProcessStarter(string exe, string workingDir)
            {
                _startInfo.WorkingDirectory = workingDir;
                _startInfo.FileName = exe;
                _startInfo.UseShellExecute = false;
                _startInfo.RedirectStandardOutput = true;
            }
            public string Run(string arguments)
            {
                _startInfo.Arguments = arguments;
                Process p = Process.Start(_startInfo);
                p.Start();
                string strOutput = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                return strOutput;
            }
        }
