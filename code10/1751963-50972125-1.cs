    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class MyComboBox : ComboBox
    {
        public MyComboBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
        }
        const int CB_SETCUEBANNER = 0x1703;
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
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetComboBoxInfo(IntPtr hWnd, ref COMBOBOXINFO pcbi);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, 
            int wParam, string lParam);
        string hint;
        public string Hint
        {
            get { return hint; }
            set { hint = value; }
        }
        private void UpdateHint()
        {
            if (!this.IsHandleCreated)
                return;
            if (DropDownStyle == ComboBoxStyle.DropDownList)
                this.Invalidate();
            else
            {
                var info = new COMBOBOXINFO();
                info.cbSize = Marshal.SizeOf(info);
                GetComboBoxInfo(Handle, ref info);
                SendMessage(Handle, CB_SETCUEBANNER, 0, Hint);
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!string.IsNullOrEmpty(Hint))
                UpdateHint();
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            string text = Hint;
            base.OnDrawItem(e);
            if (e.Index > -1)
                text = this.GetItemText(this.Items[e.Index]);
            e.DrawBackground();
            TextRenderer.DrawText(e.Graphics, text, Font,
                e.Bounds, e.ForeColor, TextFormatFlags.TextBoxControl);
        }
    }
