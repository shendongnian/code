    // Microsoft.CSharp, 4.0.30319
    // Microsoft.Office.Interop.Excel, 15.0.4420.1017
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    using Excel = Microsoft.Office.Interop.Excel;
    public static void Main(string[] args)
    {
        object ppunk = null;
        if (GetRunningObjectTable(0, out IRunningObjectTable pprot) == 0)
        {
            pprot.EnumRunning(out IEnumMoniker ppenumMoniker);
            ppenumMoniker.Reset();
            var moniker = new IMoniker[1];
            while (ppenumMoniker.Next(1, moniker, IntPtr.Zero) == 0)
            {
                CreateBindCtx(0, out IBindCtx ppbc);
                moniker[0].GetDisplayName(ppbc, null, out string ppszDisplayName);
                
                Marshal.ReleaseComObject(ppbc);
                // Identify by worksheet path
                if (ppszDisplayName.ToLower().Contains(".xls") && ppszDisplayName.ToLower().Contains("appdata"))
                {
                    pprot.GetObject(moniker[0], out object ppunkObject);
                    ppunk = ppunkObject;
                }
            }
        }
        if (ppunk != null)
        {
            Excel.Workbook workbook = ppunk as Excel.Workbook;
            Excel.Application excel = workbook.Application;
            // Do something
            dynamic title = workbook.FullName;
            excel.Quit();
        }
    }
    // https://msdn.microsoft.com/en-us/library/windows/desktop/ms684004(v=vs.85).aspx
    [DllImport("ole32.dll")]
    private static extern int GetRunningObjectTable(int reserved, out IRunningObjectTable pprot);
    // https://msdn.microsoft.com/de-de/library/windows/desktop/ms678542(v=vs.85).aspx
    [DllImport("ole32.dll")]
    private static extern void CreateBindCtx(int reserved, out IBindCtx ppbc);
