[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
public struct tagRECT {
    
    /// LONG->int
    public int left;
    
    /// LONG->int
    public int top;
    
    /// LONG->int
    public int right;
    
    /// LONG->int
    public int bottom;
}
public partial class NativeMethods {
    
    /// Return Type: int
    ///hdc: HDC->HDC__*
    ///lpchText: LPCWSTR->WCHAR*
    ///cchText: int
    ///lprc: LPRECT->tagRECT*
    ///format: UINT->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint="DrawTextW")]
public static extern  int DrawTextW([System.Runtime.InteropServices.InAttribute()] System.IntPtr hdc, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)] System.Text.StringBuilder lpchText, int cchText, ref tagRECT lprc, uint format) ;
}
