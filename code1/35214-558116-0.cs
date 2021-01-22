    static class NativeMethods
    {
        public const int WM_CREATE = 0x1;
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        public extern static int SetWindowTheme(
            IntPtr hWnd, string pszSubAppName, string pszSubIdList);
    }
    class ListView : System.Windows.Forms.ListView
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Win.WM_CREATE) {
                NativeMethods.SetWindowTheme(this.Handle, "Explorer", null);
            }
            base.WndProc(ref m);
        }
    }
