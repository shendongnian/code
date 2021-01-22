    [DllImport("user32.dll", SetLastError = true)]
       static extern IntPtr GetWindowThreadProcessId(int hWnd, out IntPtr lpdwProcessId);
    ...
    objApp = new Excel.Application();
    IntPtr processID;
    GetWindowThreadProcessId(objApp.Hwnd, out processID);
    excel = Process.GetProcessById(processID.ToInt32());
    ...
    objApp.Application.Quit();
    Marshal.FinalReleaseComObject(objApp);
    _excel.Kill();
