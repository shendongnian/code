    [DllImport("NewLib.dll",
        CallingConvention = CallingConvention.StdCall,
        CharSet = CharSet.Unicode)]
    [return: MarshalAs(UnmanagedType.BStr)]
    public static extern string DBConnet(string inputString, string connectionString);
