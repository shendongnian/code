    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    static class Program
    {
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        [STAThread]
        static void Main()
        {
            SendMessage(new Form().Handle, 0x0112, 0xF170, 2);
        }
    }
