    using System.Runtime.InteropServices; 
    private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
    private const UInt32 SWP_NOSIZE = 0x0001;
    private const UInt32 SWP_NOMOVE = 0x0002;
    private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;   
    [DllImport("user32.dll")] 
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, 
      int X, int Y, int cx, int cy, uint uFlags);
....
    frm_Save fsave = new frm_Save(); 
    fsave.Show();
    SetWindowPos(frm_Save.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
    Process p = Process.Start(process); 
    using (p)
    {
        while (!p.WaitForExit(1000))
        {
            fsave.Refresh();
        }
    }
    fsave.Close();
