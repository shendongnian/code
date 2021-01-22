     void setDate(string dateInYourSystemFormat)
        {
            var proc = new System.Diagnostics.ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = @"C:\Windows\System32";
            proc.CreateNoWindow = true;
            proc.FileName = @"C:\Windows\System32\cmd.exe";
            proc.Verb = "runas";
            proc.Arguments = "/C " + cmd;
            try
            {
                System.Diagnostics.Process.Start(proc);
            }
            catch
            {
                MessageBox.Show("Error to change time of your system");
                Application.ExitThread();
            }
        }
    void setTime(string timeInYourSystemFormat)
        {
            var proc = new System.Diagnostics.ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = @"C:\Windows\System32";
            proc.CreateNoWindow = true;
            proc.FileName = @"C:\Windows\System32\cmd.exe";
            proc.Verb = "runas";
            proc.Arguments = "/C " + cmd;
            try
            {
                System.Diagnostics.Process.Start(proc);
            }
            catch
            {
                MessageBox.Show("Error to change time of your system");
                Application.ExitThread();
            }
        }
