    public class MultiSelectNoCTRLKeyListView : ListView {
      public MultiSelectNoCTRLKeyListView() {
    
      }
    
      public const int WM_LBUTTONDOWN = 0x0201;
      protected override void WndProc(ref Message m) {
        switch (m.Msg) {
          case WM_LBUTTONDOWN:
            if (!this.MultiSelect)
              break;
    
            int x = (m.LParam.ToInt32() & 0xffff);
            int y = (m.LParam.ToInt32() >> 16) & 0xffff;
    
            var hitTest = this.HitTest(x, y);
            if (hitTest != null && hitTest.Item != null)
              hitTest.Item.Selected = !hitTest.Item.Selected;
    
            return;
        }
    
        base.WndProc(ref m);
      }
    }
