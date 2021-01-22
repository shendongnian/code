    internal class ControlScrollListener : NativeWindow, IDisposable
    {
        public event ControlScrolledEventHandler ControlScrolled;
        public delegate void ControlScrolledEventHandler(object sender, EventArgs e);
        private const uint WM_HSCROLL = 0x114;
        private const uint WM_VSCROLL = 0x115;
        private readonly Control _control;
        public ControlScrollListener(Control control)
        {
            _control = control;
            AssignHandle(control.Handle);
        }
        protected bool Disposed { get; set; }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (Disposed) return;
            if (disposing)
            {
                // Free other managed objects that implement IDisposable only
            }
            // release any unmanaged objects
            // set the object references to null
            ReleaseHandle();
            Disposed = true;
        }
        protected override void WndProc(ref Message m)
        {
            HandleControlScrollMessages(m);
            base.WndProc(ref m);
        }
        private void HandleControlScrollMessages(Message m)
        {
            if (m.Msg == WM_HSCROLL | m.Msg == WM_VSCROLL)
            {
                if (ControlScrolled != null)
                {
                    ControlScrolled(_control, new EventArgs());
                }
            }
        }
    }
