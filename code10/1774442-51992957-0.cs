    public class Wow64Interop
        {
            [DllImport("Kernel32.Dll", EntryPoint = "Wow64EnableWow64FsRedirection")]
            public static extern bool EnableWow64FSRedirection(bool enable);
        } 
