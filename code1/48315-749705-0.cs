        private static string CallPython(string script, string pyArgs, string workingDirectory, string[] standardInput)
        {
            ProcessStartInfo startInfo;
            Process process;
            string ret = "";
            try
            {
                startInfo = new ProcessStartInfo(@"c:\python25\python.exe");
                startInfo.WorkingDirectory = workingDirectory;
                if (pyArgs.Length != 0)
                    startInfo.Arguments = script + " " + pyArgs;
                else
                    startInfo.Arguments = script;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.RedirectStandardInput = true;
                process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                // write to standard input
                foreach (string si in standardInput)
                {
                    process.StandardInput.WriteLine(si);
                }
                string s;
                while ((s = process.StandardError.ReadLine()) != null)
                {
                    ret += s;
                    throw new System.Exception(ret);
                }
                while ((s = process.StandardOutput.ReadLine()) != null)
                {
                    ret += s;
                }
                return ret;
            }
            catch (System.Exception ex)
            {
                string problem = ex.Message;
                return problem;
            }
        }
