    [DllImport("user32.dll")]
    static extern int GetWindowThreadProcessId(int hWnd, out int lpdwProcessId);
    
    private void GenerateExcel()
    {
        var excel = new Microsoft.Office.Interop.Excel.Application();
        int id;
        // Find the Excel Process Id (ath the end, you kill him
        GetWindowThreadProcessId(excel.Hwnd, out id);
        Process excelProcess = Process.GetProcessById(id);
    
    try
    {
        // Your code
    }
    finally
    {
        excel.Quit();
    
        // Kill him !
        excelProcess.Kill();
    }
