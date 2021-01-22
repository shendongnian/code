    public class TestARP
    {
        private StringBuilder sbRedirectedOutput = new StringBuilder();
        public string OutputData
        {
            get { return this.sbRedirectedOutput.ToString(); }
        }
        // Asynchronous!
        public void Run()
        {
            System.Diagnostics.ProcessStartInfo ps = new System.Diagnostics.ProcessStartInfo();
            ps.FileName = "arp";
            ps.ErrorDialog = false;
            ps.Arguments = "-a";
            ps.CreateNoWindow = true; // comment this out
            ps.UseShellExecute = false; // true
            ps.RedirectStandardOutput = true; // false
            ps.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; // comment this out
            using (System.Diagnostics.Process proc = new System.Diagnostics.Process())
            {
                proc.StartInfo = ps;
                proc.Exited += new EventHandler(proc_Exited);
                proc.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(proc_OutputDataReceived);
                proc.Start();
                proc.WaitForExit();
                proc.BeginOutputReadLine(); // Comment this out
            }
        }
        void proc_Exited(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("proc_Exited: Process Ended");
        }
        void proc_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            if (e.Data != null) this.sbRedirectedOutput.Append(e.Data + Environment.NewLine);
        }
    }
