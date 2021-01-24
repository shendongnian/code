    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct COMBOBOXINFO
        {
            public int cbSize;
            public RECT rcItem;
            public RECT rcButton;
            public int stateButton;
            public IntPtr hwndCombo;
            public IntPtr hwndEdit;
            public IntPtr hwndList;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left; public int Top; public int Right; public int Bottom;
        }
        [DllImport("user32.dll")]
        public static extern bool GetComboBoxInfo(IntPtr hWnd, ref COMBOBOXINFO pcbi);
        public class ListBoxHelper : NativeWindow
        {
            private const int LB_SETTOPINDEX = 0x0197;
            public ListBoxHelper(IntPtr hwnd) { this.AssignHandle(hwnd); }
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == LB_SETTOPINDEX)
                    m.WParam = IntPtr.Zero;
                base.WndProc(ref m);
            }
        }
    }
