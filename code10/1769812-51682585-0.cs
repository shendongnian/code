    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    StreamWriter stdin = null;
    private void StartCmdProcess()
    {
        ProcessStartInfo pStartInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = "start /WAIT",
            WorkingDirectory = @"C:\",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            RedirectStandardInput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        Process cmdProcess = new Process
        {
            StartInfo = pStartInfo,
            EnableRaisingEvents = true
        };
        cmdProcess.Start();
        cmdProcess.BeginOutputReadLine();
        cmdProcess.BeginErrorReadLine();
        stdin = cmdProcess.StandardInput;
        cmdProcess.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
        {
            if (e.Data != null)
            {
                Invoke(new MethodInvoker(() =>
                {
                    rtbStdOut.AppendText(e.Data + Environment.NewLine);
                    rtbStdOut.ScrollToCaret();
                }));
            }
        };
        cmdProcess.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
        {
            if (e.Data != null)
            {
                Invoke(new MethodInvoker(() =>
                {
                    rtbStdErr.AppendText(e.Data + Environment.NewLine);
                    rtbStdErr.ScrollToCaret();
                }));
            }
        };
        cmdProcess.Exited += (object source, EventArgs ev) =>
        {
            cmdProcess.Close();
            if (cmdProcess != null)
            {
                cmdProcess.Dispose();
            }
        };
    }
