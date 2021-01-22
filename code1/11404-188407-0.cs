    [StructLayout(LayoutKind.Sequential, Size=TotalBytesInStruct),Serializable]
    public struct LPRData
    {
    /// char[15]
    [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 15)]
    public string data;
    
    /// int[15]
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 15)]
    public int[] prob;
    }
