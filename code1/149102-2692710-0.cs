    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    class MyListView : ListView {
      public MyListView() {
        this.HotTracking = true;
      }
      protected override void OnHandleCreated(EventArgs e) {
        base.OnHandleCreated(e);
        SetWindowTheme(this.Handle, "explorer", null);
      }
      [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
      public extern static int SetWindowTheme(IntPtr hWnd, string appname, string subidlist);
    }
