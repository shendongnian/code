    internal class WindowWrapper : IWin32Window
    {
        public IntPtr Handle { get; private set; }
        public WindowWrapper(IntPtr hwnd) { Handle = hwnd; }
    }
