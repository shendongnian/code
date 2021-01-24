    public struct Message_PDU
    {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
    public string commandID;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
    public string playerIndex;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
    public string score;
    }; 
