    //Used for WM_COPYDATA for messages
    [StructLayout(LayoutKind.Sequential)]
    public struct COPYDATASTRUCT
    {
        //dwData
        //The data to be passed to the receiving application.
        public IntPtr dwData;
        // cbData
        // The size, in bytes, of the data pointed to by the lpData member.
        public int cbData;
        // lpDATA
        // The data to be passed to the receiving application. This member can be NULL.
        public IntPtr lpData;
    }
    // this is the struct I am Sending
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ReturnStruct
    {
        public int i;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string card;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string responsecode;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string responsetext;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string approval;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string tranid;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string reference;
        public double d;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
        public string transactionType;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string creditCardType;
        public int EMVContact;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string applicationName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string applicationIdentifier;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string reserved;
        //public byte[] reserved;
    }
    //Allocate a pointer
    public static IntPtr IntPtrAlloc<T>(T param)
    {
        IntPtr retval = Marshal.AllocCoTaskMem(Marshal.SizeOf(param));
        Marshal.StructureToPtr(param, retval, false);
        return retval;
    }
    // Free an allocated pointer
    public static void IntPtrFree(ref IntPtr preAllocated)
    {
        Marshal.FreeCoTaskMem(preAllocated);
        preAllocated = IntPtr.Zero;
    }
    //include SendMessage
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int uMsg, UIntPtr wParam, IntPtr lParam);
    public void SendFingerPrintResult(string msg)
    { 
        // get the window to send struct
        IntPtr receiverHandle = GetWindow();
        if (receiverHandle == IntPtr.Zero) return;
        // Get the struct
        ReturnStruct ret = GetReturnStruct();
        IntPtr ptr = IntPtrAlloc(ret);
        try
        {
            var cds = new COPYDATASTRUCT
            {
                dwData = IntPtr.Zero,
                cbData = Marshal.SizeOf(ret),
                lpData = ptr
            };
            IntPtr iPtr = IntPtrAlloc(cds);
            try
            {
                SendMessage(receiverHandle, WM_COPYDATA, senderID, iPtr);
            }
            finally
            {
                IntPtrFree(ref iPtr);
            }
        }
        finally
        {
            IntPtrFree(ref ptr);
        }
    }
