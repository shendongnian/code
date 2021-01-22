    using System;
    using System.Text;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    class BoldMessageBox : IDisposable {
      private int mTries = 0;
      private Form mOwner;
      private Font mFont;
    
      public BoldMessageBox(Form owner) {
        mOwner = owner;
        owner.BeginInvoke(new MethodInvoker(findDialog));
      }
    
      private void findDialog() {
        // Enumerate windows to find the message box
        if (mTries < 0) return;
        EnumThreadWndProc callback = new EnumThreadWndProc(checkWindow);
        if (EnumThreadWindows(GetCurrentThreadId(), callback, IntPtr.Zero)) {
          if (++mTries < 10) mOwner.BeginInvoke(new MethodInvoker(findDialog));
        }
      }
      private bool checkWindow(IntPtr hWnd, IntPtr lp) {
        // Checks if <hWnd> is a dialog
        StringBuilder sb = new StringBuilder(260);
        GetClassName(hWnd, sb, sb.Capacity);
        if (sb.ToString() != "#32770") return true;
        // Got it, get the STATIC control that displays the text
        IntPtr hText = GetDlgItem(hWnd, 0xffff);
        if (hText != IntPtr.Zero) {
          // Get the current font
          IntPtr hFont = SendMessage(hText, WM_GETFONT, IntPtr.Zero, IntPtr.Zero);
          Font font = Font.FromHfont(hFont);
          // And make it bold (note the size change to keep enough space!!)
          mFont = new Font(font.FontFamily, font.SizeInPoints - 1f, FontStyle.Bold);
          SendMessage(hText, WM_SETFONT, mFont.ToHfont(), (IntPtr)1);
        }
        // Done
        return false;
      }
      public void Dispose() {
        mTries = -1;
        if (mFont != null) mFont.Dispose();
      }
    
      // P/Invoke declarations
      private const int WM_SETFONT = 0x30;
      private const int WM_GETFONT = 0x31;
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
