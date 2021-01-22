    // UNICODE_STRING for Rtl... method
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct UNICODE_STRING
    {
        public ushort Length;
        public ushort MaximumLength;
        [MarshalAs(UnmanagedType.LPWStr)]
        string Buffer;
        public UNICODE_STRING(string buffer)
        {
            if (buffer == null)
                Length = MaximumLength = 0;
            else
                Length = MaximumLength = unchecked((ushort)(buffer.Length * 2));
            Buffer = buffer;
        }
    }
    
    // RtlIsNameInExpression method from NtDll.dll system library
    public static class NtDll
    {
        [DllImport("NtDll.dll", CharSet=CharSet.Unicode, ExactSpelling=true)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool RtlIsNameInExpression(
            ref UNICODE_STRING Expression,
            ref UNICODE_STRING Name,
            [MarshalAs(UnmanagedType.U1)]
            bool IgnoreCase,
            IntPtr Zero
            );
    }
    
    public bool MatchMask(string mask, string fileName)
    {
        // Expression must be uppercase for IgnoreCase == true (see MSDN for RtlIsNameInExpression)
        UNICODE_STRING expr = new UNICODE_STRING(mask.ToUpper());
        UNICODE_STRING name = new UNICODE_STRING(fileName);
    
        if (NtDll.RtlIsNameInExpression(ref expr, ref name, true, IntPtr.Zero))
        {
            // MATCHES !!!
        }
    }
