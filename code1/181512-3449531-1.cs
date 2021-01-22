        public Process p = null;
        private void Send_Click(object sender, System.EventArgs e)
        {
            
            p.StandardInput.WriteLine("D:");
            p.StandardInput.WriteLine(@"cd D:\");
            p.StandardInput.WriteLine(txtInput.Text);
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            ProcessStartInfo procStarter = new ProcessStartInfo("cmd.exe");
            procStarter.RedirectStandardOutput = true;
            procStarter.RedirectStandardInput = true;
            procStarter.UseShellExecute = false;
            procStarter.CreateNoWindow = true;
            
            p = Process.Start(procStarter);
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            p.BeginOutputReadLine();
        }
        void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            addTextToOutput(e.Data);
        }
        private void addTextToOutput(string text)
        {
            if (txtOutput.InvokeRequired)
            {
                addTextCallback cb = new addTextCallback(addTextToOutput);
                this.Invoke(cb, new Object[] { text });
            }
            else
            {
                txtOutput.Text += text+ System.Environment.NewLine;
            }
        }
        delegate void addTextCallback(String text);
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            p.Close();
        }
