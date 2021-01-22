    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]  
    public struct TMPData  
    {              
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]  
        public string Lastname;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]  
        public string Firstname;  
        [MarshalAs(UnmanagedType.R8)]  
        public double Birthday;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]  
        public string Pid;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]  
        public string Title;  
        [MarshalAs(UnmanagedType.Bool)]  
        public bool Female;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]  
        public string Street;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]  
        public string ZipCode;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]  
        public string City;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]  
        public string Phone;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]  
        public string Fax;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]  
        public string Department;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]  
        public string Company;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]  
        public string Pn;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]  
        public string In;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]  
        public string Hi;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]  
        public string Account;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]  
        public string Valid;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]  
        public string Status;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]  
        public string Country;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]  
        public string NameAffix;  
        [MarshalAs(UnmanagedType.R4)]  
        public int W;  
        [MarshalAs(UnmanagedType.R4)]  
        public int H;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]  
        public string Bp;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]  
        public string SocialSecurityNumber;  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]  
        public string State;  
    }  
    [DllImport("MyDll.dll")]         
    [return: MarshalAs(UnmanagedType.Bool)]         
    public static extern bool Init(ref TMPData tmpData,ref int ErrorCode, bool ResetFatalError);         
         
    [DllImport("MyDll.dll")]         
    [return: MarshalAs(UnmanagedType.Bool)]         
    public static extern bool GetData(ref TMPData tmpData);    
