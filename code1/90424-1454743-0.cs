    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_GROUPS
    {
        public UInt32 GroupCount;
        // Followed by this:
        [MarshalAs(UnmanagedType.ByValArray)] // <--
        public SID_AND_ATTRIBUTES[] Groups;
    }
