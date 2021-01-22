    private void RunCommandLine(string commandText)
        {
            try
            {
                Process proc = new Process();
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.Arguments = "/c " + commandText;
                txtOutput.Text += "C:\\> " + commandText + "\r\n";
                proc.Start();
                txtOutput.Text += proc.StandardOutput.ReadToEnd().Replace("\n", "\r\n");
                txtOutput.Text += proc.StandardError.ReadToEnd().Replace("\n", "\r\n");
                proc.WaitForExit();
                txtOutput.Refresh();
            }
            catch (Exception ex)
            {
                txtOutput.Text = ex.Message;
            }
        }
