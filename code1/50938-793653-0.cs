    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct T_SAMPLE_STRUCT
    {
        /// int
        public int num;
        /// char[20]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string text;
    }
