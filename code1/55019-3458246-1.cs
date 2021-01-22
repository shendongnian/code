        [DllImport("user32")]
        public static extern int SetForegroundWindow(IntPtr hwnd);         
        ...
        private void frmLogin_Shown(object sender, EventArgs e)
        {
          SetForegroundWindow(this.Handle);
        }
        private void frmLogin_Deactivate(object sender, EventArgs e)
        {
            TopMost = false;
        }
