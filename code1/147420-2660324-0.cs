    using System;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    class MessageBoxClicker : IDisposable {
      private Timer mTimer;
    
      public MessageBoxClicker() {
        mTimer = new Timer();
        mTimer.Interval = 50;
        mTimer.Enabled = true;
        mTimer.Tick += new EventHandler(findDialog);
      }
    
      private void findDialog(object sender, EventArgs e) {
        // Enumerate windows to find the message box
        EnumThreadWndProc callback = new EnumThreadWndProc(checkWindow);
        EnumThreadWindows(GetCurrentThreadId(), callback, IntPtr.Zero);
        GC.KeepAlive(callback);
      }
    
      private bool checkWindow(IntPtr hWnd, IntPtr lp) {
        // Checks if <hWnd> is a dialog
        StringBuilder sb = new StringBuilder(260);
        GetClassName(hWnd, sb, sb.Capacity);
        if (sb.ToString() != "#32770") return true;
        // Got it, send the BN_CLICKED message for the OK button
        SendMessage(hWnd, WM_COMMAND, (IntPtr)IDC_OK, IntPtr.Zero);
        // Done
        return false;
      }
    
      public void Dispose() {
        mTimer.Enabled = false;
      }
    
      // P/Invoke declarations
      private const int WM_COMMAND = 0x111;
      private const int IDC_OK = 2;
      private delegate bool EnumThreadWndProc(IntPtr hWnd, IntPtr lp);
      [DllImport("user32.dll")]
      private static extern bool EnumThreadWindows(int tid, EnumThreadWndProc callback, IntPtr lp);
      [DllImport("kernel32.dll")]
      private static extern int GetCurrentThreadId();
      [DllImport("user32.dll")]
      private static extern int GetClassName(IntPtr hWnd, StringBuilder buffer, int buflen);
      [DllImport("user32.dll")]
      private static extern IntPtr GetDlgItem(IntPtr hWnd, int item);
      [DllImport("user32.dll")]
      private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
