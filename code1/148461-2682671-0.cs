    public void BeginUpdate() {
      SendMessage(this.Handle, 0xb, (IntPtr)0, IntPtr.Zero);
    }
    public void EndUpdate() {
      SendMessage(this.Handle, 0xb, (IntPtr)1, IntPtr.Zero); 
    }
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private extern static IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp); 
