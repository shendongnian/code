    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class MyListView : ListView {
      protected override void WndProc(ref Message m) {
        if (m.Msg == 0x201 || m.Msg == 0x203) {  // Trap WM_LBUTTONDOWN + double click
          var pos = new Point(m.LParam.ToInt32());
          var loc = this.HitTest(pos);
          switch (loc.Location) {
            case ListViewHitTestLocations.None:
            case ListViewHitTestLocations.AboveClientArea:
            case ListViewHitTestLocations.BelowClientArea:
            case ListViewHitTestLocations.LeftOfClientArea:
            case ListViewHitTestLocations.RightOfClientArea:
              return;  // Don't let the native control see it
          }
        }
        base.WndProc(ref m);
      }
    }
