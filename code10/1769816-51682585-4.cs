    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    StreamWriter stdin = null;
    private void StartCmdProcess()
    {
        ProcessStartInfo pStartInfo = new ProcessStartInfo {
            FileName = "cmd.exe",
            Arguments = "start /WAIT",
            WorkingDirectory = Environment.SystemDirectory,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            RedirectStandardInput = true,
            UseShellExecute = false,
            CreateNoWindow = true,
        };
        Process cmdProcess = new Process {
            StartInfo = pStartInfo,
            EnableRaisingEvents = true,
            // Test without and with this
            // When SynchronizingObject is set, no need to BeginInvoke()
            //SynchronizingObject = this
        };
        cmdProcess.Start();
        cmdProcess.BeginErrorReadLine();
        cmdProcess.BeginOutputReadLine();
        stdin = cmdProcess.StandardInput;
        cmdProcess.OutputDataReceived += (s, evt) => {
            if (evt.Data != null)
            {
                BeginInvoke(new MethodInvoker(() => {
                    rtbStdOut.AppendText(evt.Data + Environment.NewLine);
                    rtbStdOut.ScrollToCaret();
                }));
            }
        };
        cmdProcess.ErrorDataReceived += (s, evt) => {
            if (evt.Data != null) {
                BeginInvoke(new Action(() => {
                    rtbStdErr.AppendText(evt.Data + Environment.NewLine);
                    rtbStdErr.ScrollToCaret();
                }));
            }
        };
        cmdProcess.Exited += (s, evt) => {
            cmdProcess.Close();
            if (cmdProcess != null) {
                cmdProcess.Dispose();
            }
        };
    }
