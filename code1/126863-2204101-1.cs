    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace WordLateBindingSample
    {
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00020400-0000-0000-C000-000000000046")]
        public interface IDispatch
        {
        }
    
        class Program
        {
            [DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    
            [DllImport("Oleacc.dll")]
            static extern int AccessibleObjectFromWindow(int hwnd, uint dwObjectID, byte[] riid, out IDispatch ptr);
    
            public delegate bool EnumChildCallback(int hwnd, ref int lParam);
    
            [DllImport("User32.dll")]
            public static extern bool EnumChildWindows(int hWndParent, EnumChildCallback lpEnumFunc, ref int lParam);
    
            [DllImport("User32.dll")]
            public static extern int GetClassName(int hWnd, StringBuilder lpClassName, int nMaxCount);
    
            public static bool EnumChildProc(int hwndChild, ref int lParam)
            {
                StringBuilder buf = new StringBuilder(128);
                GetClassName(hwndChild, buf, 128);
                if (buf.ToString() == "_WwG")
                {
                    lParam = hwndChild;
                    return false;
                }
                return true;
            }
    
            static void Main(string[] args)
            {
                // Use the window class name ("OpusApp") to retrieve a handle to Word's main window.
                // Alternatively you can get the window handle via the process id:
                // int hwnd = (int)Process.GetProcessById(wordPid).MainWindowHandle;
                //
                int hwnd = (int)FindWindow("OpusApp", null);
    
                if (hwnd != 0)
                {
                    int hwndChild = 0;
    
                    // Search the accessible child window (it has class name "_WwG") 
                    // as described in http://msdn.microsoft.com/en-us/library/dd317978%28VS.85%29.aspx
                    //
                    EnumChildCallback cb = new EnumChildCallback(EnumChildProc);
                    EnumChildWindows(hwnd, cb, ref hwndChild);
    
                    if (hwndChild != 0)
                    {
                        // We call AccessibleObjectFromWindow, passing the constant OBJID_NATIVEOM (defined in winuser.h) 
                        // and IID_IDispatch - we want an IDispatch pointer into the native object model.
                        //
                        const uint OBJID_NATIVEOM = 0xFFFFFFF0;
                        Guid IID_IDispatch = new Guid("{00020400-0000-0000-C000-000000000046}");
                        IDispatch ptr;
    
                        int hr = AccessibleObjectFromWindow(hwndChild, OBJID_NATIVEOM, IID_IDispatch.ToByteArray(), out ptr);
    
                        if (hr >= 0)
                        {
                            object wordApp = ptr.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, ptr, null);
    
                            object version = wordApp.GetType().InvokeMember("Version", BindingFlags.GetField | BindingFlags.InvokeMethod | BindingFlags.GetProperty, null, wordApp, null);
                            Console.WriteLine(string.Format("Word version is: {0}", version));
                        }
                    }
                }
            }
        }
    }
