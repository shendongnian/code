       using System;
        using System.Runtime.InteropServices;
        using System.Windows;
        using System.Windows.Interop;
...
    [DllImport("user32.dll")]
    static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X,
       int Y, int cx, int cy, uint uFlags);
    
    const UInt32 SWP_NOSIZE = 0x0001;
    const UInt32 SWP_NOMOVE = 0x0002;
    const UInt32 SWP_NOACTIVATE = 0x0010;
    
    static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
    
    public static void SetBottom(Window window)
    {
        IntPtr hWnd = new WindowInteropHelper(window).Handle;
        SetWindowPos(hWnd, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_NOACTIVATE);
    }
