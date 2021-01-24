    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
<!----!>
    public class MyComboBox : ComboBox {
        [StructLayout(LayoutKind.Sequential)]
        struct COMBOBOXINFO {
            public int cbSize;
            public RECT rcItem;
            public RECT rcButton;
            public int stateButton;
            public IntPtr hwndCombo;
            public IntPtr hwndEdit;
            public IntPtr hwndList;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct RECT {
            public int Left; public int Top; public int Right; public int Bottom;
        }
        [DllImport("user32.dll")]
        static extern bool GetComboBoxInfo(IntPtr hWnd, ref COMBOBOXINFO pcbi);
        ListBoxHelper listBoxHelper;
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            var info = new COMBOBOXINFO();
            info.cbSize = Marshal.SizeOf(info);
            GetComboBoxInfo(this.Handle, ref info);
            listBoxHelper = new ListBoxHelper(info.hwndList);
        }
        private class ListBoxHelper : NativeWindow {
            private const int LB_SETTOPINDEX = 0x0197;
            public ListBoxHelper(IntPtr hwnd) { this.AssignHandle(hwnd); }
            protected override void WndProc(ref Message m) {
                if (m.Msg == LB_SETTOPINDEX)
                    m.WParam = IntPtr.Zero;
                base.WndProc(ref m);
            }
        }
    }
