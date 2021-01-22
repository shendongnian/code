    //The import
    using System.Runtime.InteropServices;
    
    // The declaration
    [DllImport("user32.dll")]
    public static extern int ExitWindowsEx(int uFlags, int dwReserved);
     
    // The call
     ExitWindowsEx(0, 0);
