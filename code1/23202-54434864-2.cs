    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            [DllImport("User32.dll", CharSet = CharSet.Auto)]
            private static extern IntPtr SendMessage(IntPtr h, int msg, int wParam, uint[] lParam);
            private const int EM_SETTABSTOPS = 0x00CB;
            private const char vbTab = '\t';
    
            public Form1()
            {
                InitializeComponent();
    
                var tabs = new uint[] { 25 * 4 };
    
                textBox1.Text = "Bernard" + vbTab + "32";
                SendMessage(textBox1.Handle, EM_SETTABSTOPS, 1, tabs);
                textBox2.Text = "Luc" + vbTab + "47";
                SendMessage(textBox2.Handle, EM_SETTABSTOPS, 1, tabs);
                textBox3.Text = "François-Victor" + vbTab + "12";
                SendMessage(textBox3.Handle, EM_SETTABSTOPS, 1, tabs);
            }
        }
    }
