    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            [DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
            [DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, StringBuilder lParam);
            [DllImport("user32.dll")]
            public static extern IntPtr FindWindowEx(IntPtr Parent,IntPtr child, string classname, string WindowTitle);
            const int WM_GETTEXT = 0x00D;
            const int WM_GETTEXTLENGTH = 0x00E;
            private void Form1_Load(object sender, EventArgs e)
            {
                Process procc = GetProcByName("Example");
                // You can use spy++ to get main window handle so you don't need to use this code
                if (procc != null)
                {
                    IntPtr child = FindWindowEx(procc.MainWindowHandle, IntPtr.Zero, "WindowsForms10.EDIT.app.0.2bf8098_r16_ad1", null);
                    // Use Spy++ to get textbox's class name. for me it was  "WindowsForms10.EDIT.app.0.2bf8098_r16_ad1"
                    int length = SendMessage(child, WM_GETTEXTLENGTH, 0, 0);
                    StringBuilder text = new StringBuilder();
                    text = new StringBuilder(length + 1);
                    int retr2 = SendMessage(child, WM_GETTEXT, length + 1, text);
                    MessageBox.Show(text.ToString());
                   // now you will see  value of the your textbox on another application  
    
                }
             
            }
            public Process GetProcByName(string Name)
            {
                Process proc = null;
                Process[] processes = Process.GetProcesses();
                for (int i = 0; i < processes.Length; i++)
                { if (processes[i].ProcessName == Name)proc = processes[i]; }
                return proc;
            }
           
        }
    }
