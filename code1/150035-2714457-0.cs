    using System;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Runtime.InteropServices;
    
    class MyTrackBar : TrackBar {
      public Rectangle Slider {
        get {
          RECT rc = new RECT();
          SendMessageRect(this.Handle, TBM_GETTHUMBRECT, IntPtr.Zero, ref rc);
          return new Rectangle(rc.left, rc.top, rc.right - rc.left, rc.bottom - rc.top);
        }
      }
      public Rectangle Channel {
        get {
          RECT rc = new RECT();
          SendMessageRect(this.Handle, TBM_GETCHANNELRECT, IntPtr.Zero, ref rc);
          return new Rectangle(rc.left, rc.top, rc.right - rc.left, rc.bottom - rc.top);
        }
      }
      private const int TBM_GETCHANNELRECT = 0x400 + 26;
      private const int TBM_GETTHUMBRECT = 0x400 + 25;
      private struct RECT { public int left, top, right, bottom; }
      [DllImport("user32.dll", EntryPoint = "SendMessageW")]
      private static extern IntPtr SendMessageRect(IntPtr hWnd, int msg, IntPtr wp, ref RECT lp);
    }
