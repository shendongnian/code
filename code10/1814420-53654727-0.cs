    using System;
    using System.Diagnostics;
    using System.Text;
    using System.Windows.Forms;
    namespace ConsoleOutput_test
    {
    public partial class Form1 : Form
    {
        Process sortProcess;
        private static StringBuilder sortOutput = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sortProcess = new Process();
            sortProcess.StartInfo.FileName = "C:\\Windows\\System32\\cmd.exe";
            // Set UseShellExecute to false for redirection.
            sortProcess.StartInfo.CreateNoWindow = true;
            sortProcess.StartInfo.UseShellExecute = false;
            // Redirect the standard output of the sort command.  
            // This stream is read asynchronously using an event handler.
            sortProcess.StartInfo.RedirectStandardOutput = true;
            sortProcess.StartInfo.RedirectStandardInput = true;
            sortProcess.StartInfo.RedirectStandardError = true;
            sortOutput = new StringBuilder("");
            // Set our event handler to asynchronously read the sort output.
            sortProcess.OutputDataReceived += new DataReceivedEventHandler(SortOutputHandler);
            sortProcess.ErrorDataReceived += new DataReceivedEventHandler(SortErrorHandler);
            // Redirect standard input as well.  This stream
            // is used synchronously.
            sortProcess.StartInfo.RedirectStandardInput = true;
            // Start the process.
            sortProcess.Start();
            // Start the asynchronous read of the sort output stream.
            sortProcess.BeginOutputReadLine();
            while (!sortProcess.HasExited)
            {
                Application.DoEvents(); // This keeps your form responsive by processing events
            }
        }
        private void SortOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (txtConsole.InvokeRequired) { txtConsole.BeginInvoke(new DataReceivedEventHandler(SortOutputHandler), new[] { sendingProcess, outLine }); }
            else
            {
                txtConsole.AppendText(Environment.NewLine + outLine.Data);
            }
        }
        private void SortErrorHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (txtConsole.InvokeRequired) { txtConsole.BeginInvoke(new DataReceivedEventHandler(SortErrorHandler), new[] { sendingProcess, outLine }); }
            else
            {
                txtConsole.AppendText(Environment.NewLine + outLine.Data);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            sortProcess.StandardInput.WriteLine(txtOutput.Text);
            txtOutput.Text = "";
        }
    }
    }
