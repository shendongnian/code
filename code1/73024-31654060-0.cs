     class ExcelInteropService
    {
        private const string EXCEL_CLASS_NAME = "EXCEL7";
        private const uint DW_OBJECTID = 0xFFFFFFF0;
        private static Guid rrid = new Guid("{00020400-0000-0000-C000-000000000046}");
        public delegate bool EnumChildCallback(int hwnd, ref int lParam);
        [DllImport("Oleacc.dll")]
        public static extern int AccessibleObjectFromWindow(int hwnd, uint dwObjectID, byte[] riid, ref Window ptr);
        [DllImport("User32.dll")]
        public static extern bool EnumChildWindows(int hWndParent, EnumChildCallback lpEnumFunc, ref int lParam);
        [DllImport("User32.dll")]
        public static extern int GetClassName(int hWnd, StringBuilder lpClassName, int nMaxCount);
        public static Application GetExcelInterop(int? processId = null)
        {
            var p = processId.HasValue ? Process.GetProcessById(processId.Value) : Process.Start("excel.exe");
            try
            {
                Thread.Sleep(5000);
                return new ExcelInteropService().SearchExcelInterop(p);
            }
            catch (Exception)
            {
                Debug.Assert(p != null, "p != null");
                return GetExcelInterop(p.Id);
            }
        }
        private bool EnumChildFunc(int hwndChild, ref int lParam)
        {
            var buf = new StringBuilder(128);
            GetClassName(hwndChild, buf, 128);
            if (buf.ToString() == EXCEL_CLASS_NAME) { lParam = hwndChild; return false; }
            return true;
        }
        private Application SearchExcelInterop(Process p)
        {
            Window ptr = null;
            int hwnd = 0;
            int hWndParent = (int)p.MainWindowHandle;
            if (hWndParent == 0) throw new Exception();
            EnumChildWindows(hWndParent, EnumChildFunc, ref hwnd);
            if (hwnd == 0) throw new Exception();
            int hr = AccessibleObjectFromWindow(hwnd, DW_OBJECTID, rrid.ToByteArray(), ref ptr);
            if (hr < 0) throw new Exception();
            return ptr.Application;
        }
    }
