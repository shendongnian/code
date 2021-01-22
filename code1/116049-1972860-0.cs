    public const UInt32 Infinite = 0xffffffff;
    public const Int32 Startf_UseStdHandles = 0x00000100;
    public const Int32 StdOutputHandle = -11;
    public const Int32 StdErrorHandle = -12;
    
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct StartupInfo
    {
        public int cb;
        public String reserved;
        public String desktop;
        public String title;
        public int x;
        public int y;
        public int xSize;
        public int ySize;
        public int xCountChars;
        public int yCountChars;
        public int fillAttribute;
        public int flags;
        public UInt16 showWindow;
        public UInt16 reserved2;
        public byte reserved3;
        public IntPtr stdInput;
        public IntPtr stdOutput;
        public IntPtr stdError;
    }
    
    public struct ProcessInformation
    {
        public IntPtr process;
        public IntPtr thread;
        public int processId;
        public int threadId;
    }
    
    
    [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool CreateProcessWithLogonW(
        String userName,
        String domain,
        String password,
        UInt32 logonFlags,
        String applicationName,
        String commandLine,
        UInt32 creationFlags,
        UInt32 environment,
        String currentDirectory,
        ref   StartupInfo startupInfo,
        out  ProcessInformation processInformation);
    
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool GetExitCodeProcess(IntPtr process, ref UInt32 exitCode);
    
    [DllImport("Kernel32.dll", SetLastError = true)]
    public static extern UInt32 WaitForSingleObject(IntPtr handle, UInt32 milliseconds);
    
    [DllImport("Kernel32.dll", SetLastError = true)]
    public static extern IntPtr GetStdHandle(IntPtr handle);
    
    [DllImport("Kernel32.dll", SetLastError = true)]
    public static extern bool CloseHandle(IntPtr handle);
    
    
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        StartupInfo startupInfo = new StartupInfo();
        startupInfo.reserved = null;
        startupInfo.flags &= Startf_UseStdHandles;
        startupInfo.stdOutput = (IntPtr)StdOutputHandle;
        startupInfo.stdError = (IntPtr)StdErrorHandle;
    
        UInt32 exitCode = 123456;
        ProcessInformation processInfo = new ProcessInformation();
    
        String command = @"c:\windows\system32\ping.exe 127.0.0.1";
        String user = "admin";
        String domain = System.Environment.MachineName;
        String password = "password";
        String currentDirectory = System.IO.Directory.GetCurrentDirectory();
    
        try
        {
            CreateProcessWithLogonW(
                user,
                domain,
                password,
                (UInt32)1,
                null,
                command,
                (UInt32)0,
                (UInt32)0,
                currentDirectory,
                ref startupInfo,
                out processInfo);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    
        Console.WriteLine("Running ...");
        WaitForSingleObject(processInfo.process, Infinite);
        GetExitCodeProcess(processInfo.process, ref exitCode);
    
        Console.WriteLine("Exit code: {0}", exitCode);
    
        CloseHandle(processInfo.process);
        CloseHandle(processInfo.thread);
    }
