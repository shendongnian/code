        void RunWithRedirect(string cmdargs)
        {
            var proc = new Process()
            {
                StartInfo = new ProcessStartInfo("cmd.exe", "/k " + cmdargs)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                },
                EnableRaisingEvents = true
            };
            // see below for output handler
            proc.ErrorDataReceived += proc_DataReceived;
            proc.OutputDataReceived += proc_DataReceived;
            proc.Start();
            proc.BeginErrorReadLine();
            proc.BeginOutputReadLine();
            proc.WaitForExit();
        }
        void proc_DataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
                Dispatcher.BeginInvoke(new Action( () => txtOut.Text += (Environment.NewLine + e.Data) ));
        }
