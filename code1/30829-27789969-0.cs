    class SuspendDrawingUpdate : IDisposable
    {
        private const int WM_SETREDRAW = 0x000B;
        private readonly Control _control;
        private readonly NativeWindow _window;
        public SuspendDrawingUpdate(Control control)
        {
            _control = control;
            var msgSuspendUpdate = Message.Create(_control.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);
            _window = NativeWindow.FromHandle(_control.Handle);
            _window.DefWndProc(ref msgSuspendUpdate);
        }
        public void Dispose()
        {
            var wparam = new IntPtr(1);  // Create a C "true" boolean as an IntPtr
            var msgResumeUpdate = Message.Create(_control.Handle, WM_SETREDRAW, wparam, IntPtr.Zero);
            _window.DefWndProc(ref msgResumeUpdate);
            _control.Invalidate();
        }
    }
