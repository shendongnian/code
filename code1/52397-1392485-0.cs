    ///Return Type: DWORD->unsigned int
    ///hWnd: HWND->HWND__*
    ///lpdwProcessId: LPDWORD->DWORD*
    [System.Runtime.InteropServices.DllImportAttribute( "user32.dll", EntryPoint = "GetWindowThreadProcessId" )]
    public static extern int GetWindowThreadProcessId ( [System.Runtime.InteropServices.InAttribute()] System.IntPtr hWnd, out int lpdwProcessId );
    private int _ExcelPID = 0;
    Process _ExcelProcess;
    private Application _ExcelApp = new ApplicationClass();
    GetWindowThreadProcessId( new IntPtr(_ExcelApp.Hwnd), out _ExcelPID );
    _ExcelProcess = System.Diagnostics.Process.GetProcessById( _ExcelPID );
    ...
    _ExcelProcess.Kill();
