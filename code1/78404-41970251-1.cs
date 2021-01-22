    [StructLayout(LayoutKind.Sequential)]
    public struct SECURITY_HANDLE
    {
        public IntPtr LowPart;
        public IntPtr HighPart;
        public SECURITY_HANDLE(int dummy)
        {
            LowPart = HighPart = IntPtr.Zero;
        }
    };
