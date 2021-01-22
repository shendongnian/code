            static string GetOldestFile(string dirName)
            {
                ProcessStartInfo si = new ProcessStartInfo("cmd.exe");
                si.RedirectStandardInput = true;
                si.RedirectStandardOutput = true;
                si.UseShellExecute = false;
                Process p = Process.Start(si);
                p.StandardInput.WriteLine(@"dir " + dirName + " /o:D");
                p.StandardInput.WriteLine(@"exit");
                string output = p.StandardOutput.ReadToEnd();
                string[] splitters = { Environment.NewLine };
                string[] lines = output.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
                // find first line with a valid date that does not have a <DIR> in it
                DateTime result;
                int i = 0;
                while (i < lines.Length)
                {
                    string[] tokens = lines[i].Split(' ');
                    if (DateTime.TryParse(tokens[0], out result))
                    {
                        if (!lines[i].Contains("<DIR>"))
                        {
                            return tokens[tokens.Length - 1];
                        }
                    }
                    i++;
                }
    
                return "";
            }
