    using System.Diagnostics;
    private string getFirewallStatus()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe");
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            Process process = Process.Start(processStartInfo);
            if (process != null)
            {
                process.StandardInput.WriteLine("netsh advfirewall show allprofiles | find \"State\"");
                process.StandardInput.Close();
                string outputString = process.StandardOutput.ReadToEnd();
                int count = 0;
                for (int i = 0; i < outputString.Length - 3; i++)
                {
                    if (outputString.Substring(i, 3).CompareTo(@"OFF") == 0)
                    {
                        count++;
                        switch (count)
                        {
                            case 1: label16.Text = "Off"; label16.ForeColor = System.Drawing.Color.Green; break;
                            case 2: label17.Text = "Off"; label17.ForeColor = System.Drawing.Color.Green; break;
                            case 3: label18.Text = "Off"; label18.ForeColor = System.Drawing.Color.Green; break;
                            default: MessageBox.Show("Firewall status unable to be found!"); break;
                        }
                    }
                    else if (outputString.Substring(i, 2).CompareTo("ON") == 0)
                    {
                        count++;
                    }
                }
                count = 0;
                return outputString;
            }
            return string.Empty;
        }    
