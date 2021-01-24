    const uint OBJID_NATIVEOM = 0xFFFFFFF0;
    var procs = new List<Process>(Process.GetProcessesByName("MSACCESS.EXE"));
    foreach (var p in procs)
    {
        var mainHandle = (int)p.MainWindowHandle;
        if (mainHandle > 0)
        {
            var IID_IDispatch = new Guid("{00020400-0000-0000-C000-000000000046}");
            Microsoft.Office.Interop.Access.Application app = null;
            int res = AccessibleObjectFromWindow(mainHandle, OBJID_NATIVEOM, IID_IDispatch.ToByteArray(), ref app);
            if (res >= 0)
            {
                Debug.Assert(app.hWndAccessApp == mainHandle);
                Console.WriteLine(app.Name);
            }
        }
    }
