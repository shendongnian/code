    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    public class MyWidget : Control {
      public MyWidget() {
        this.BackColor = Color.Yellow;
      }
      protected override void OnGotFocus(EventArgs e) {
        CreateCaret(this.Handle, IntPtr.Zero, 2, this.Height - 2);
        SetCaretPos(2, 1);
        ShowCaret(this.Handle);
        base.OnGotFocus(e);
      }
      protected override void OnLostFocus(EventArgs e) {
        DestroyCaret();
        base.OnLostFocus(e);
      }
      [DllImport("user32.dll", SetLastError = true)]
      private static extern bool CreateCaret(IntPtr hWnd, IntPtr hBmp, int w, int h);
      [DllImport("user32.dll", SetLastError = true)]
      private static extern bool SetCaretPos(int x, int y);
      [DllImport("user32.dll", SetLastError = true)]
      private static extern bool ShowCaret(IntPtr hWnd);
      [DllImport("user32.dll", SetLastError = true)]
      private static extern bool DestroyCaret();
    }
