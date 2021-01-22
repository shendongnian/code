    [DllImport("shell32.dll", SetLastError = true)]
    static extern IntPtr CommandLineToArgvW(
        [MarshalAs(UnmanagedType.LPWStr)] string lpCmdLine, out int pNumArgs);
    
    public static string[] CommandLineToArgs(string commandLine)
    {
		// uncomment these 2 lines if you encounter a encoding problem
		// var bytes = Encoding.UTF32.GetBytes(commandLine);
		// commandLine=Encoding.Unicode.GetString(bytes);
        int argc;
        var argv = CommandLineToArgvW(commandLine, out argc);        
        if (argv == IntPtr.Zero) 
		{
            throw new System.ComponentModel.Win32Exception();
		}
        try
        {
			var a = new IntPtr[argc];
			Marshal.Copy(argv, a, 0, a.Length);
			var args = a.Select(x => Marshal.PtrToStringUni(x)).ToArray();
            return args;
        }
        finally
        {
            Marshal.FreeHGlobal(argv);
        }
    }
