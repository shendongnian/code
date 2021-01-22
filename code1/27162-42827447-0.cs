    public static class WindowHelper
    {
        public static bool? ShowDialogNonBlocking(this Window window)
        {
            var frame = new DispatcherFrame();
            void closeHandler(object sender, EventArgs args)
            {
                frame.Continue = false;
            }
            try
            {
                window.Owner.SetNativeEnabled(false);
                window.Closed += closeHandler;
                window.Show();
                Dispatcher.PushFrame(frame);
            }
            finally
            {
                window.Closed -= closeHandler;
                window.Owner.SetNativeEnabled(true);
            }
            return window.DialogResult;
        }
        const int GWL_STYLE = -16;
        const int WS_DISABLED = 0x08000000;
        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        static void SetNativeEnabled(this Window window, bool enabled)
        {
            var handle = new WindowInteropHelper(window).Handle;
            SetWindowLong(handle, GWL_STYLE, GetWindowLong(handle, GWL_STYLE) &
                ~WS_DISABLED | (enabled ? 0 : WS_DISABLED));
        }
    }
