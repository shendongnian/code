    [DllImport("User32.dll")]
    static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
    ...
    int objExcelProcessId = 0;
    Excel.Application objExcel = new Excel.Application();
    GetWindowThreadProcessId(new IntPtr(objExcel.Hwnd), out objExcelProcessId);
    Process.GetProcessById(objExcelProcessId).Kill();
