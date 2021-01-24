    private void TextBox1_Loaded(object sender, RoutedEventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(delegate (object o, DoWorkEventArgs args)
            {
               
            });
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(delegate (object o, RunWorkerCompletedEventArgs args)
            {
                TextBox1.Text = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "ProcessorNameString", null) + Environment.NewLine;
                TextBox1.Text += "Memory:  " + getRAMsize() + Environment.NewLine;
                TextBox1.Text += "Free Space:  " + GetTotalFreeSpace(sysdrive) + " GB" + Environment.NewLine;
                if (Is64BitSystem)
                {
                    TextBox1.Text += getOS() + " 64bit" + Environment.NewLine;
                }
                else
                {
                    TextBox1.Text += getOS() + " 32 Bit" + Environment.NewLine;
                }
                TextBox1.Text += "MAC Address : " + System.Text.RegularExpressions.Regex.Replace(GetMacAddress().ToString(), ".{2}", "$0 ") + Environment.NewLine;
                TextBox1.Text += av();
            });
            bw.RunWorkerAsync();
        }
