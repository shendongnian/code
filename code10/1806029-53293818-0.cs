    [ProgId("SampleActX.SampleActX")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [Guid("7F6A5914-9C8A-4977-AF5B-DE9D45E01B44")]
    [DllImport("user32.dll", SetLastError = true)]
    static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    [ComVisible(true)]
    public class SampleActX
    {
        [ComVisible(true)]
        public string SayHello()
        {
            return "Hello World!";
        }
        public void SetIEWindowOnTop()
        {
            var myId = Process.GetCurrentProcess().Id;//Fetches the pid of the current tab in IE only
            var query = string.Format("SELECT ParentProcessId FROM Win32_Process WHERE ProcessId = {0}", myId); //Finding the actual IE window handle
            var search = new ManagementObjectSearcher("root\\CIMV2", query);
            var results = search.Get().GetEnumerator();
            results.MoveNext();
            var queryObj = results.Current;
            var parentId = (uint)queryObj["ParentProcessId"];
            var parent = Process.GetProcessById((int)parentId);
            IntPtr windoHandle = parent.MainWindowHandle;//Fetches the parent window handle
            var bresu = SetWindowPos(windoHandle,   //Sets the window on Top
                        HWND_TOPMOST,
                        0, 0, 0, 0,
                       SWP_NOSIZE|SWP_SHOWWINDOW);
        }
    }
