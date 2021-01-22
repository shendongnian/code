    public sealed class CursorApplier : IDisposable
    {
        private Control _control;
        private Cursor _previous;
        public CursorApplier(Control control, Cursor cursor)
        {
            _control = control;
            _previous = _control.Cursor;
            ApplyCursor(cursor);
        }
        public void Dispose()
        {
            ApplyCursor(_previous);
        }
        private void ApplyCursor(Cursor cursor)
        {
            if (_control.Disposing || _control.IsDisposed)
                return;
            if (_control.InvokeRequired)
                _control.Invoke(new MethodInvoker(() => _control.Cursor = cursor));
            else
                _control.Cursor = cursor;
        }
    }
    // then...
    using (new CursorApplier(control, Cursors.WaitCursor))
    {
        // some work here
    }
