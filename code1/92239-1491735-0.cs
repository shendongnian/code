    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace Sample
    {
        public class Window
        {
            public string Title { get; set; }
            public int Handle { get; set; }
            public string ProcessName { get; set; }
        }
    
        public class WindowHelper
        {
            /// <summary>
            /// Win32 API Imports
            /// </summary>
            [DllImport("user32.dll")]
            private static extern int GetWindowText(IntPtr hWnd, StringBuilder title, int size);
            [DllImport("user32.dll")]
            private static extern int EnumWindows(EnumWindowsProc ewp, int lParam);
            [DllImport("user32.dll")]
            private static extern bool IsWindowVisible(IntPtr hWnd);
            [DllImport("user32.dll", SetLastError = true)]
            static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
    
            public delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);
    
            private List<Window> _openOfficeWindows;
    
            public List<Window> GetOpenOfficeWindows()
            {
                _openOfficeWindows = new List<Window>();
                EnumWindowsProc ewp = new EnumWindowsProc(EvalWindow);
                EnumWindows(ewp, 0);
    
                return _openOfficeWindows;
            }
    
            private bool EvalWindow(IntPtr hWnd, int lParam)
            {
                if (!IsWindowVisible(hWnd))
                    return (true);
    
                uint lpdwProcessId;
                StringBuilder title = new StringBuilder(256);
    
                GetWindowThreadProcessId(hWnd, out lpdwProcessId);
                GetWindowText(hWnd, title, 256);
    
                Process p = Process.GetProcessById((int)lpdwProcessId);
                if (p != null && p.ProcessName.ToLower().Contains("soffice"))
                {
                    _openOfficeWindows.Add(new Window() { Title = title.ToString(), Handle = hWnd.ToInt32(), ProcessName = p.ProcessName });
                }
    
                return (true);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                WindowHelper helper = new WindowHelper();
    
                List<Window> openOfficeWindows = helper.GetOpenOfficeWindows();
    
                foreach (var item in openOfficeWindows)
                {
                    if (item.Title.EndsWith("- OpenOffice.org Writer"))
                    {
                        Console.WriteLine("Writer is running");
                    }
                }
            }
        }
    }
