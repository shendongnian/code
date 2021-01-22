    // http://stackoverflow.com/questions/779363/how-to-use-use-late-binding-to-get-excel-instance
    // ReSharper disable InconsistentNaming
    using System;
    using System.Runtime.InteropServices;
    using System.Globalization;
    using System.Reflection;
    using System.Text;
    namespace LateBindingWord {
        /// <summary> Interface definition for Word.Window interface </summary>
        [Guid("00020962-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IWordWindow {
        }
        /// <summary>
        /// This class is needed as a workaround to http://support.microsoft.com/default.aspx?scid=kb;en-us;320369
        /// Excel automation will fail with the follwoing error on systems with non-English regional settings:
        /// "Old format or invalid type library. (Exception from HRESULT: 0x80028018 (TYPE_E_INVDATAREAD))" 
        /// </summary>
        class UiLanguageHelper : IDisposable {
            private readonly CultureInfo _currentCulture;
            public UiLanguageHelper() {
                // save current culture and set culture to en-US 
                _currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            }
            public void Dispose() {
                // reset to original culture 
                System.Threading.Thread.CurrentThread.CurrentCulture = _currentCulture;
            }
        }
        class Program {
            [DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [DllImport("Oleacc.dll")]
            static extern int AccessibleObjectFromWindow(int hwnd, uint dwObjectID, byte[] riid, out IWordWindow ptr);
            public delegate bool EnumChildCallback(int hwnd, ref int lParam);
            [DllImport("User32.dll")]
            public static extern bool EnumChildWindows(int hWndParent, EnumChildCallback lpEnumFunc, ref int lParam);
            [DllImport("User32.dll")]
            public static extern int GetClassName(int hWnd, StringBuilder lpClassName, int nMaxCount);
            public static bool EnumChildProc(int hwndChild, ref int lParam) {
                var buf = new StringBuilder(128);
                GetClassName(hwndChild, buf, 128);
                Console.WriteLine(buf.ToString());
                if (buf.ToString() == "_WwG") { 
                    lParam = hwndChild;
                    return false;
                }
                return true;
            }
            static void Main() {
                // Use the window class name ("XLMAIN") to retrieve a handle to Excel's main window.
                // Alternatively you can get the window handle via the process id:
                // int hwnd = (int)Process.GetProcessById(excelPid).MainWindowHandle;
                // var p=Process.GetProcesses().FirstOrDefault(x => x.ProcessName=="WINWORD");
                var hwnd = (int) FindWindow("OpusApp", null);
                if (hwnd == 0) 
                    throw new Exception("Can't find Word");
                // Search the accessible child window (it has class name "_WwG") // http://msdn.microsoft.com/en-us/library/windows/desktop/dd317978%28v=vs.85%29.aspx
                var hwndChild = 0;
                var cb = new EnumChildCallback(EnumChildProc);
                EnumChildWindows(hwnd, cb, ref hwndChild);
                if (hwndChild == 0) 
                    throw new Exception("Can't find Automation Child Window");
                // We call AccessibleObjectFromWindow, passing the constant OBJID_NATIVEOM (defined in winuser.h) 
                // and IID_IDispatch - we want an IDispatch pointer into the native object model.
                const uint OBJID_NATIVEOM = 0xFFFFFFF0;
                var IID_IDispatch = new Guid("{00020400-0000-0000-C000-000000000046}");
                IWordWindow ptr;
                var hr = AccessibleObjectFromWindow(hwndChild, OBJID_NATIVEOM, IID_IDispatch.ToByteArray(), out ptr);
                if (hr < 0) 
                    throw new Exception("Can't get Accessible Object");
                // We successfully got a native OM IDispatch pointer, we can QI this for
                // an Excel Application using reflection (and using UILanguageHelper to 
                // fix http://support.microsoft.com/default.aspx?scid=kb;en-us;320369)
                using (new UiLanguageHelper()) {
                    var wordApp = ptr.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, ptr, null);
                    var version = wordApp.GetType().InvokeMember("Version", BindingFlags.GetField | BindingFlags.InvokeMethod | BindingFlags.GetProperty, null, wordApp, null);
                    Console.WriteLine("Word version is: {0}", version);
                    dynamic wordAppd = ptr.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, ptr, null);
                    Console.WriteLine("Version: " + wordAppd.Version);
                }
            }
        }
    }
