    List<string[]> results = new List<string[]>();
            using (Process p = new Process())
            {
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.Arguments = "/c arp -a";
                p.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
                p.Start();
                string line;
                while ((line = p.StandardOutput.ReadLine()) != null)
                {
                    if (line != "" && !line.Contains("Interface") && !line.Contains("Physical Address"))
                    {
                        var lineArr = line.Trim().Split(' ').Select(n => n).Where(n => !string.IsNullOrEmpty(n)).ToArray();
                        var arrResult = new string[]
                    {
                       lineArr[0],
                       lineArr[1],
                       lineArr[2]
                    };
                        results.Add(arrResult);
                    }
                }
                p.WaitForExit();
            }
