    class GuestControl : Control
    {
        private IntPtr CWnd { get; }
    
        public GuestControl()
        {
            CWnd = attach(Handle);
        }
        protected override void Dispose(bool disposing)
        {
           if (disposing)
           {
              detach(CWnd);
           }
    
           base.Dispose(disposing);
        }
        [DllImport("your_mfc_dll")]
        private static extern IntPtr attach(IntPtr hwnd);
        [DllImport("your_mfc_dll")]
        private static extern void detach(IntPtr hwnd);
    }
