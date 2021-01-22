public struct DEV_BROADCAST_DEVICEINTERFACE
{
    public int dbcc_size;
    public int dbcc_devicetype;
    public int dbcc_reserved;
    public Guid dbcc_classguid;
[System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 255, ArraySubType = System.Runtime.InteropServices.UnmanagedType.LPArray)]
    public string dbcc_name;
}
