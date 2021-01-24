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
        public byte card_len;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string card;
        public byte name_len;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string name;
        public byte responsecode_len;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string responsecode;
        public byte responsetext_len;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string responsetext;
        public byte approval_len;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string approval;
        public byte tranid_len;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string tranid;
        public byte reference_len;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string reference;
        public double d;
        public byte transactionType_len;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
        public string transactionType;
        public byte creditCardType_len;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string creditCardType;
        public int EMVContact;
        public byte applicationName_len;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string applicationName;
        public byte applicationIdentifier_len;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string applicationIdentifier;
        public byte reserved_len;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string reserved;
    }
    public ReturnStruct GetReturnStruct()
    {
        var ret = new ReturnStruct();
        ret.i = ...;
        ret.card = ...;
        ret.card_len = Math.Max(System.Text.Encoding.Default.GetByteCount(ret.card), 50);
        ret.name = ...;
        ret.name_len = Math.Max(System.Text.Encoding.Default.GetByteCount(ret.name), 100);
        ret.responsecode = ...;
        ret.responsecode_len = Math.Max(System.Text.Encoding.Default.GetByteCount(ret.responsecode), 5);
        ret.responsetext = ...;
        ret.responsetext_len = Math.Max(System.Text.Encoding.Default.GetByteCount(ret.responsetext), 100);
        ret.approval = ...;
        ret.approval_len = Math.Max(System.Text.Encoding.Default.GetByteCount(ret.approval), 15);
        ret.tranid = ...;
        ret.tranid_len = Math.Max(System.Text.Encoding.Default.GetByteCount(ret.tranid), 50);
        ret.reference = ...;
        ret.reference_len = Math.Max(System.Text.Encoding.Default.GetByteCount(ret.reference), 16);
        ret.d = ...;
        ret.transactionType = ...;
        ret.transactionType_len = Math.Max(System.Text.Encoding.Default.GetByteCount(ret.transactionType), 24);
        ret.creditCardType = ...;
        ret.creditCardType_len = Math.Max(System.Text.Encoding.Default.GetByteCount(ret.creditCardType), 10);
        ret.EMVContact = ...;
        ret.applicationName = ...;
        ret.applicationName_len = Math.Max(System.Text.Encoding.Default.GetByteCount(ret.applicationName), 50);
        ret.applicationIdentifier = ...;
        ret.applicationIdentifier_len = Math.Max(System.Text.Encoding.Default.GetByteCount(ret.applicationIdentifier), 15);
        ret.reserved = ...;
        ret.reserved_len = Math.Max(System.Text.Encoding.Default.GetByteCount(ret.reserved), 10);
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
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
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
