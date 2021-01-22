public class TestDir
    {
        private StringBuilder sbRedirectedOutput = new StringBuilder();
        public string OutputData
        {
            get { return this.sbRedirectedOutput.ToString(); }
        }
        public void Run()
        {
            System.Diagnostics.ProcessStartInfo ps = new System.Diagnostics.ProcessStartInfo();
            ps.FileName = "cmd";
            ps.ErrorDialog = false;
            ps.Arguments = string.Format("dir {0} /o-d", path_name);
            ps.CreateNoWindow = true;
            ps.UseShellExecute = false;
            ps.RedirectStandardOutput = true;
            ps.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            using (System.Diagnostics.Process proc = new System.Diagnostics.Process())
            {
                proc.StartInfo = ps;
                proc.Exited += new EventHandler(proc_Exited);
                proc.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(proc_OutputDataReceived);
                proc.Start();
                proc.WaitForExit();
                proc.BeginOutputReadLine();
                while (!proc.HasExited) ;
            }
        }
        void proc_Exited(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("proc_Exited: Process Ended");
        }
        void proc_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            if (e.Data != null) this.sbRedirectedOutput.Append(e.Data + Environment.NewLine);
            //System.Diagnostics.Debug.WriteLine("proc_OutputDataReceived: Data: " + e.Data);
        }
    }
