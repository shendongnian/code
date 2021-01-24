    using System;
    using System.Diagnostics;
    using System.Windows;
    
    namespace SO_Continous_Process_Output
    {
        public partial class MainWindow : Window
        {
            private Process process;
    
            public MainWindow()
            {
                InitializeComponent();
    
                CreateProcess("ping", "-t 127.0.0.1 -w 1000", "");
            }
    
            //Execute a new process
            private void CreateProcess(string fileName, string arguments, string workdir)
            {
                // Process process = new Process();
                process = new Process();
                process.StartInfo.FileName = fileName;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.WorkingDirectory = workdir;
                process.OutputDataReceived += proc_OutputDataReceived;
    
                process.Start();
                process.BeginOutputReadLine();
            }
    
            void proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    tb_outputtext.Text = tb_outputtext.Text + "\n" + e.Data;
                    tb_outputtext.ScrollToEnd();
                }));
            }
        }
    }
