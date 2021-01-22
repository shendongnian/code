    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace WindowsFormsApplication1 {
        public partial class Form1 : Form {
            public Form1() {
                InitializeComponent();
                timer1.Interval = 10;
                timer1.Tick += new EventHandler(timer1_Tick);
                button1.Click += new EventHandler(button1_Click);
            }
            void timer1_Tick(object sender, EventArgs e) {
                int pos = textBox1.SelectionStart;
                int len = textBox1.SelectionLength;
                SendMessage(textBox1.Handle, 11, IntPtr.Zero, IntPtr.Zero);
                textBox1.AppendText(DateTime.Now.ToString() + Environment.NewLine);
                SendMessage(textBox1.Handle, 11, (IntPtr)1, IntPtr.Zero);
                //if (textBox1 is RichTextBox) textBox1.Invalidate();
                textBox1.SelectionStart = pos;
                textBox1.SelectionLength = len;
            }
            private void button1_Click(object sender, EventArgs e) {
                timer1.Enabled = !timer1.Enabled;
            }
            [DllImport("user32.dll")]
            private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        }
    }
