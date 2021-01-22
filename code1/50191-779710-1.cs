    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace ExcelLateBindingSample
    {
        /// <summary>
        /// Interface definition for Excel.Window interface
        /// </summary>
        [Guid("00020893-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface ExcelWindow
        {
        }
    
        /// <summary>
        /// This class is needed as a workaround to http://support.microsoft.com/default.aspx?scid=kb;en-us;320369
        /// Excel automation will fail with the follwoing error on systems with non-English regional settings:
        /// "Old format or invalid type library. (Exception from HRESULT: 0x80028018 (TYPE_E_INVDATAREAD))" 
        /// </summary>
        class UILanguageHelper : IDisposable
        {
            private CultureInfo _currentCulture;
    
            public UILanguageHelper()
            {
                // save current culture and set culture to en-US 
                _currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            }
    
            public void Dispose()
            {
                // reset to original culture 
                System.Threading.Thread.CurrentThread.CurrentCulture = _currentCulture;
            }
        }
    
        class Program
        {
            [DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    
            [DllImport("Oleacc.dll")]
            static extern int AccessibleObjectFromWindow(int hwnd, uint dwObjectID, byte[] riid, out ExcelWindow ptr);
    
            public delegate bool EnumChildCallback(int hwnd, ref int lParam);
    
            [DllImport("User32.dll")]
            public static extern bool EnumChildWindows(int hWndParent, EnumChildCallback lpEnumFunc, ref int lParam);
    
            [DllImport("User32.dll")]
            public static extern int GetClassName(int hWnd, StringBuilder lpClassName, int nMaxCount);
    
            public static bool EnumChildProc(int hwndChild, ref int lParam)
            {
                StringBuilder buf = new StringBuilder(128);
                GetClassName(hwndChild, buf, 128);
                if (buf.ToString() == "EXCEL7")
                {
                    lParam = hwndChild;
                    return false;
                }
                return true;
            }
    
            static void Main(string[] args)
            {
                // Use the window class name ("XLMAIN") to retrieve a handle to Excel's main window.
                // Alternatively you can get the window handle via the process id:
                // int hwnd = (int)Process.GetProcessById(excelPid).MainWindowHandle;
                //
                int hwnd = (int)FindWindow("XLMAIN", null); 
                
                if (hwnd != 0)
                {
                    int hwndChild = 0;
    
                    // Search the accessible child window (it has class name "EXCEL7") 
                    EnumChildCallback cb = new EnumChildCallback(EnumChildProc);
                    EnumChildWindows(hwnd, cb, ref hwndChild);
    
                    if (hwndChild != 0)
                    {
                        // We call AccessibleObjectFromWindow, passing the constant OBJID_NATIVEOM (defined in winuser.h) 
                        // and IID_IDispatch - we want an IDispatch pointer into the native object model.
                        //
                        const uint OBJID_NATIVEOM = 0xFFFFFFF0;
                        Guid IID_IDispatch = new Guid("{00020400-0000-0000-C000-000000000046}");
                        ExcelWindow ptr;
    
                        int hr = AccessibleObjectFromWindow(hwndChild, OBJID_NATIVEOM, IID_IDispatch.ToByteArray(), out ptr);
    
                        if (hr >= 0)
                        {
                            // We successfully got a native OM IDispatch pointer, we can QI this for
                            // an Excel Application using reflection (and using UILanguageHelper to 
                            // fix http://support.microsoft.com/default.aspx?scid=kb;en-us;320369)
                            //
                            using (UILanguageHelper fix = new UILanguageHelper())
                            {
                                object xlApp = ptr.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, ptr, null);
    
                                object version = xlApp.GetType().InvokeMember("Version", BindingFlags.GetField | BindingFlags.InvokeMethod | BindingFlags.GetProperty, null, xlApp, null);
                                Console.WriteLine(string.Format("Excel version is: {0}" + version));
                            }
                        }
                    }
                }
            }
        }
    }
