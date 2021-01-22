    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TEXTMSGSTR
    {
        public IntPtr Sender;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        public string Text;
    }
