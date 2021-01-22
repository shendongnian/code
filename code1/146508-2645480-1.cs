[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet=System.Runtime.InteropServices.CharSet.Ansi)]
public struct SCS3OverVwPg {
    
    /// int
    public int iOvrPgNo;
    
    /// char[30]
    [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst=30)]
    public string sOvrPgTitle;
}
