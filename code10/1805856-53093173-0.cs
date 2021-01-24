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
                
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                cmd.Start();
                cmd.StandardInput.WriteLine($@"{textBox1.Text}");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
    
                string text = cmd.StandardOutput.ReadToEnd();
    
                foreach (var item in text.Split('\r'))
                {
                    listBox1.Items.Add(item);
                }
    
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
        }
    }
