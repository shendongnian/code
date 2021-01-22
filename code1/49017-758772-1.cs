    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Process p = Process.Start("notepad.exe");
                Thread.Sleep(500); // Allow the process to open it's window
                SetParent(p.MainWindowHandle, panel1.Handle);
            }
    
            [DllImport("user32.dll")]
            static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        }
    }
