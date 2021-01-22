    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    class MyTextBox : TextBox {
      private int mRightMargin;
      [DefaultValue(0)]
      public int RightMargin {
        get { return mRightMargin; }
        set {
          if (value < 0) throw new ArgumentOutOfRangeException();
          mRightMargin = value;
          if (this.IsHandleCreated) updateMargin();
        }
      }
      protected override void OnHandleCreated(EventArgs e) {
        base.OnHandleCreated(e);
        if (mRightMargin > 0) updateMargin();
      }
      private void updateMargin() {
        // Send EM_SETMARGINS
        SendMessage(this.Handle, 0xd3, (IntPtr)2, (IntPtr)(mRightMargin << 16));
      }
      [DllImport("user32.dll", CharSet = CharSet.Auto)]
      private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
