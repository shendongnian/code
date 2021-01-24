    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp26
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            Process cmd = new Process();
            private void Form1_Load(object sender, EventArgs e)
            {
    
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.OutputDataReceived += Cmd_OutputDataReceived;
                cmd.Start();
                cmd.BeginOutputReadLine();
    
            }
    
            private void Cmd_OutputDataReceived(object sender, DataReceivedEventArgs e)
            {
                SetText(e.Data);
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                cmd.StandardInput.WriteLine($@"{textBox1.Text}");
                cmd.StandardInput.Flush();
    
            }
    
            delegate void StringArgReturningVoidDelegate(string text);
            private void SetText(string text)
            { // InvokeRequired required compares the thread ID of the
              // calling thread to the thread ID of the creating thread.
              // If these threads are different, it returns true.
    
                if (text != null)
                {
    
    
                    if (listBox1.InvokeRequired)
                    {
                        StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(SetText);
                        this.Invoke(d, new object[] { text });
                    }
                    else
                    {
                        listBox1.Items.Add(text);
    
                    }
    
                }
            }
        }
    }
