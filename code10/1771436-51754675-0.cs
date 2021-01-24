            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "file.bat";
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            string[] splits = output.Split('\n');
            List<string> results = new List<string>();
            foreach (string s in splits)
            {
                var twoParts = s.Split(':');
                if (twoParts.Length == 2)
                {
                    //Here you will apply checks for IP address and other mac etc
                    //after that add those values to result list and get on last
                    if (twoParts[0].Contains("IPv4"))
                        results.Add(twoParts[1]);
                    else if (twoParts[0].Contains("Physical"))
                        results.Add(twoParts[1]);
                    else if (twoParts[0].Contains("DNS"))
                        results.Add(twoParts[1]);
                    else if (twoParts[0].Contains("Subnet Mask"))
                        results.Add(twoParts[1]);
                }
            }
            string data = "";
            foreach (var d in results)
            {
                data += d + "\n";
            }
            MessageBox.Show(data);
