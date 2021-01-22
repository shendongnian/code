    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace SO_ToolTip
    {
        public partial class Form1 : Form
        {
            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                WindowWrapper windowWrapper = new WindowWrapper(GetDesktopWindow());
                ToolTip toolTip = new ToolTip();
                toolTip.Show("Blah blah... Blah blah... Blah blah...", windowWrapper, 1, 1, 10000);
            }
        }
        public class WindowWrapper : IWin32Window
        {
            public WindowWrapper(IntPtr handle)
            {
                Handle = handle;
            }
            public IntPtr Handle { get; protected set; }
        }
    }
