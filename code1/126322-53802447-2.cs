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
        [DllImport("attach")]
        private static extern IntPtr attach(IntPtr hwnd);
        [DllImport("attach")]
        private static extern void detach(IntPtr hwnd);
    }
