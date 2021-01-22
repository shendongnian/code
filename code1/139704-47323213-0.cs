    public class TextBoxHint : TextBox
    {
        string _hint;
        public string Hint
        {
            get { return _hint; }
            set { _hint = value; OnHintChanged(); }
        }
        protected virtual void OnHintChanged()
        {
            SendMessage(this.Handle, EM_SETCUEBANNER, 1, _hint);
        }
        const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
    }
