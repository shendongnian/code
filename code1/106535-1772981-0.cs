        private void InitializeInterpreter()
        {
            InterProc.StartInfo.UseShellExecute = false;
            InterProc.StartInfo.FileName = "Echoer.exe";
            InterProc.StartInfo.RedirectStandardInput = true;
            InterProc.StartInfo.RedirectStandardOutput = true;
            InterProc.StartInfo.RedirectStandardError = true;
            InterProc.StartInfo.CreateNoWindow = true;
            InterProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            InterProc.OutputDataReceived += new DataReceivedEventHandler(InterProcOutputHandler);
            bool started = InterProc.Start();
            InterProc.BeginOutputReadLine();
        }
        private void AppendTextInBox(TextBox box, string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action<TextBox, string>)AppendTextInBox, OutputTextBox, text);
            }
            else
            {
                box.Text += text;
            }
        }
        private void InterProcOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            AppendTextInBox(OutputTextBox, outLine.Data + Environment.NewLine);
        }
        private void Enterbutton_Click(object sender, EventArgs e)
        {
            InterProc.StandardInput.WriteLine(CommandTextBox.Text);
        }
