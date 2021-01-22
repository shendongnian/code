    internal class WindowHandler
    {
        internal NativeWindow MainWindow { get; private set;}
        internal WindowHandler()
        {
            MainWindow = new NativeWindow();
            MainWindow.AssignHandle(Process.GetCurrentProcess().Handle);
        }
        internal void Dispose()
        {
            MainWindow.ReleaseHandle();
        }
    }
