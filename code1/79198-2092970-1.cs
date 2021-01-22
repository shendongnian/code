    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace TestWindowsAPI
    {
        public partial class Form1 : Form
        {
            [DllImport("user32.dll")]
            public static extern IntPtr GetForegroundWindow();
    
            [DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                IntPtr thisWindow = GetForegroundWindow();
                IntPtr lastWindow = GetWindow(thisWindow, 2);
    
                tbThisWindow.Text = thisWindow.ToString();
                tbLastWindow.Text = lastWindow.ToString();
            }
        }
    }
