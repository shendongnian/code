    public delegate int KeyboardHookProc(int nCode, int wParam, ref GlobalKeyboardHookStruct lParam);
    public int hookProc(int nCode, int wParam, ref GlobalKeyboardHookStruct lParam)
    {
        // ...
    }
    public void hook()
    {
        _hookProc = new KeyboardHookProc(hookProc);
        IntPtr hInstance = LoadLibrary("user32");
        hookHandle = SetWindowsHookEx(WH_KEYBOARD_LL, _hookProc, hInstance, 0);
    }
    
    KeyboardHookProc _hookProc;
