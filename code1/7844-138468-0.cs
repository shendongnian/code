    class CustomWindow : IDisposable
    {
        delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
    
        [System.Runtime.InteropServices.StructLayout(
            System.Runtime.InteropServices.LayoutKind.Sequential,
           CharSet = System.Runtime.InteropServices.CharSet.Unicode
        )]
        struct WNDCLASS
        {
            public uint style;
            public WndProc lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
            public string lpszMenuName;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
            public string lpszClassName;
        }
    
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern System.UInt16 RegisterClassW(
            [System.Runtime.InteropServices.In] ref WNDCLASS lpWndClass
        );
    
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr CreateWindowExW(
           UInt32 dwExStyle,
           [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
           string lpClassName,
           [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
           string lpWindowName,
           UInt32 dwStyle,
           Int32 x,
           Int32 y,
           Int32 nWidth,
           Int32 nHeight,
           IntPtr hWndParent,
           IntPtr hMenu,
           IntPtr hInstance,
           IntPtr lpParam
        );
    
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern System.IntPtr DefWindowProcW(
            IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam
        );
    
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern bool DestroyWindow(
            IntPtr hWnd
        );
    
        private const int ERROR_CLASS_ALREADY_EXISTS = 1410;
    
        private bool m_disposed;
        private IntPtr m_hwnd;
    
        public void Dispose() 
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        private void Dispose(bool disposing) 
        {
            if (!m_disposed) {
                if (disposing) {
                    // Dispose managed resources
                }
    
                // Dispose unmanaged resources
                if (m_hwnd != IntPtr.Zero) {
                    DestroyWindow(m_hwnd);
                    m_hwnd = IntPtr.Zero;
                }
    
            }
        }
    
        public CustomWindow(string class_name){
    
            if (class_name == null) throw new System.Exception("class_name is null");
            if (class_name == String.Empty) throw new System.Exception("class_name is empty");
            
            // Create WNDCLASS
            WNDCLASS wind_class = new WNDCLASS();
            wind_class.lpszClassName = class_name;
            wind_class.lpfnWndProc = CustomWndProc;
    
            UInt16 class_atom = RegisterClassW(ref wind_class);
    
            int last_error = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
    
            if (class_atom == 0 && last_error != ERROR_CLASS_ALREADY_EXISTS) {
                throw new System.Exception("Could not register window class");
            }
    
            // Create window
            m_hwnd = CreateWindowExW(
                0,
                class_name,
                String.Empty,
                0,
                0,
                0,
                0,
                0,
                IntPtr.Zero,
                IntPtr.Zero,
                IntPtr.Zero,
                IntPtr.Zero
            );
        }
    
        private static IntPtr CustomWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam) 
        {
            return DefWindowProcW(hWnd, msg, wParam, lParam);
        }
    }
