    interface IPlatform
    {
        void DoSomething();
    }
    class WindowsImpl : IPlatform
    {
        public void DoSomething()
        {
            // Do something on Windows
        }
    }
    class LinuxImpl : IPlatform
    {
        public void DoSomething()
        {
            // Do something on Linux
        }
    }
    // Somewhere else
    var platform = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? new WindowsImpl() : new LinuxImpl();
    platform.DoSomething();
