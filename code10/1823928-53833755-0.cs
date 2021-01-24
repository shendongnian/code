    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    namespace WindowsFormsApplication30
    {
        public partial class Form1 : Form
        {
            [DllImport("user32.dll", SetLastError = true)]
            static extern System.UInt32 GetWindowLong(IntPtr hWnd, int nIndex);
            [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
            private static extern int SetWindowLong32(IntPtr hWnd, int nIndex, uint dwNewLong);
            [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
            static extern int SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte bAlpha, uint dwFlags);
            public const int GWL_EXSTYLE = -20;
            public const uint WS_EX_LAYERED = 0x80000;
            public const uint LWA_ALPHA = 0x2;
            public const uint LWA_COLORKEY = 0x1;
            public Form1()
            {
                InitializeComponent();
                IntPtr Handle = this.Handle;
                UInt32 windowLong = GetWindowLong(Handle, GWL_EXSTYLE);
                SetWindowLong32(Handle, GWL_EXSTYLE, (uint)(windowLong ^ WS_EX_LAYERED));
                SetLayeredWindowAttributes(Handle, 0, 128, LWA_ALPHA);
            }
        }
    }
