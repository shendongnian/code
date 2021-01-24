    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    
    namespace testApp
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                using (Process tProc = new Process())
                {
                    ProcessStartInfo t = new ProcessStartInfo();
                    t.CreateNoWindow = true;
                    t.FileName = Environment.SystemDirectory + "\\robocopy.exe";
                    t.Arguments = "/?";
                    t.UseShellExecute = false;
                    t.CreateNoWindow = true;
                    t.RedirectStandardOutput = true;
                    t.RedirectStandardError = true;
    
                    Process p = new Process();
                    p.StartInfo = t;
                    p.OutputDataReceived += new DataReceivedEventHandler(P_OutputDataReceived);
                    p.Start();
                    p.BeginOutputReadLine();                  
                }
            }
    
            private void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
            {
                try
                {
                    Trace.WriteLine(e.Data);
                    this.BeginInvoke(new MethodInvoker(() =>
                    {
                        textBox1.AppendText(e.Data ?? string.Empty);
                    }));
                }
                catch (System.Exception x)
                {
                    MessageBox.Show(x.ToString());
                }
            }
        }
    }
