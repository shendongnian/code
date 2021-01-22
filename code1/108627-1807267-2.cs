    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct SearchCriteria
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4]
        public string m_DataName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1]
        public string m_Wildcard;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2]
        public string m_Comparator;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 75]
        public string m_DataValue;
    }
