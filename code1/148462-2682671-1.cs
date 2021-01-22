    public void BeginUpdate() {
      SendMessage(this.Handle, WM_SETREDRAW, (IntPtr)0, IntPtr.Zero);
    }
    public void EndUpdate() {
      SendMessage(this.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero); 
    }
    // P/invoke declarations
    private const int WM_SETREDRAW = 0xb;
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private extern static IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp); 
