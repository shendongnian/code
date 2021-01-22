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
