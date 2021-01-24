    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class MyComboBox : ComboBox
    {
        public MyComboBox()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 40;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
            public int Width { get { return Right - Left; } }
            public int Height { get { return Bottom - Top; } }
        }
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_SHOWWINDOW = 0x0040;
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, 
            int X, int Y, int cx, int cy, int uFlags);
        [DllImport("user32.dll")]
        public static extern bool GetComboBoxInfo(IntPtr hWnd, ref COMBOBOXINFO pcbi);
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
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetupEdit();
            Invalidate();
        }
        private int buttonWidth = SystemInformation.HorizontalScrollBarArrowWidth;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0xF)
            {
                using (var g = this.CreateGraphics())
                {
                    var r = new Rectangle(2, 2,
                        ClientRectangle.Width - buttonWidth - 2,
                        ClientRectangle.Height - 4);
                    g.FillRectangle(Brushes.White, r);
                }
            }
            base.WndProc(ref m);
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            SetupEdit();
        }
        private void SetupEdit()
        {
            var info = new COMBOBOXINFO();
            info.cbSize = Marshal.SizeOf(info);
            GetComboBoxInfo(this.Handle, ref info);
            SetWindowPos(info.hwndEdit, IntPtr.Zero, 3,
                (this.Height - Font.Height) / 2,
                ClientRectangle.Width - buttonWidth - 3,
                ClientRectangle.Height - Font.Height - 4,
                SWP_NOZORDER);
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            e.DrawBackground();
            var txt = "";
            if (e.Index >= 0)
                txt = GetItemText(Items[e.Index]);
            TextRenderer.DrawText(e.Graphics, txt, Font, e.Bounds, 
                ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }
    }
