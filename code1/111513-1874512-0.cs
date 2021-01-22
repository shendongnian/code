    using System;
    using System.Windows.Forms;
    
    class MyTabControl : TabControl {
      protected override void OnKeyDown(KeyEventArgs e) {
        if (e.KeyCode == Keys.Tab && (e.KeyData & Keys.Control) != Keys.None) {
          bool forward = (e.KeyData & Keys.Shift) == Keys.None;
          // Do your stuff
          //...
        }
        else base.OnKeyDown(e);
      }
    }
