    using System.Runtime.InteropServices;
    
    public static class MyClass
    {
        [DllImport("Kernel32.dll")]
        public static extern Boolean IsWindowsServer();
    }
