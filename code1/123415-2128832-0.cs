    using System;
    using System.Windows.Forms;
    
    class MyTabControl : TabControl {
      public event EventHandler<KeyEventArgs> ArrowKeys;
      
      protected void OnArrowKeys(KeyEventArgs e) {
        EventHandler<KeyEventArgs> handler = ArrowKeys;
        if (handler != null) handler(this, e);
      }
      protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
        if (keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Left || keyData == Keys.Right) {
          var e = new KeyEventArgs(keyData);
          OnArrowKeys(e);
          if (e.Handled) return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
      }
    }
