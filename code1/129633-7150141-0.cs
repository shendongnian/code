    [StructLayoutAttribute(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
    public struct MyStruct_Name
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 25)]
        public string name;
    }
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct MyStruct
    {
        public int siOrder;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6)]
        public MyStruct_Name aaszNames;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I4)]
        public int[] siId;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I4)]
        public int[] siTones;
    }
