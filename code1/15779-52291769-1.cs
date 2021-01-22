    public static class ControlExtensions
    {
        public static void Invoke(this Control control, Action action)
        {
            try
            {
                if (!control.IsDisposed) control.Invoke(action);
            }
            catch (ObjectDisposedException) { }
        }
    }
