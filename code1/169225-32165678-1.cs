    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace Win32ComboBoxHeightExample
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            [DllImport("user32.dll")]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
            private const Int32 CB_SETITEMHEIGHT = 0x153;
    
            private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
            {
                SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                SetComboBoxHeight(comboBox1.Handle, 150);
                comboBox1.Refresh();
            }
        }
    }
