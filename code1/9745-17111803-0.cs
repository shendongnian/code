        static void TryToKillXlApp(Excel.Application xlApp)
        {
            if (xlApp != null)
            {
                int excelProcessId = 0;
                GetWindowThreadProcessId(xlApp.Hwnd, out excelProcessId);
                Process p = Process.GetProcessById(excelProcessId);
                p.Kill();
                xlApp = null;
            }
        }
        [DllImport("user32.dll")]
        static extern int GetWindowThreadProcessId(int hWnd, out int lpdwProcessId);
