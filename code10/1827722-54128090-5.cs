    [ComVisible(true)]
    public class AdminClass : ServicedComponent
    {
        public int DoSomethingAsAdmin()
        {
            // test something that a normal user shouldn't see
            return Directory.GetFiles(Path.Combine(Environment.SystemDirectory, "config")).Length;
        }
        public string WindowsIdentityCurrentName => WindowsIdentity.GetCurrent().Name;
        public string CurrentProcessFilePath => Process.GetCurrentProcess().MainModule.FileName;
        // depending on how you call regsvcs, you can run as a 32 or 64 bit surrogate dllhost.exe
        public bool Is64BitProcess => Environment.Is64BitProcess;
    }
