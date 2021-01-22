    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using Microsoft.Office.Interop.Excel;
    class Program
    {
        /// <summary> 
        /// Win32 API import for getting the process Id. 
        /// The out param is the param we are after. I have no idea what the return value is. 
        /// </summary> 
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out IntPtr ProcessId); 
 
        static void Main(string[] args)
        {
            var app = new Application();
            IntPtr hwnd = new IntPtr(app.Hwnd);
            IntPtr processId;
            IntPtr foo = GetWindowThreadProcessId(hwnd, out processId);
            Process proc = Process.GetProcessById(processId.ToInt32());
            proc.Kill(); // set breakpoint here and watch the Windows Task Manager kill this exact EXCEL.EXE
            app.Quit(); // should give you a "Sorry, I can't find this Excel session since you killed it" Exception.
        }
    }
