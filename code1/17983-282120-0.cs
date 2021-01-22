    using System;
    using System.Windows.Forms;
    
    public class MyRtb : RichTextBox {
      protected override bool ProcessCmdKey(ref Message m, Keys keyData) {
        if (keyData == (Keys.I | Keys.Control)) {
          // Do your stuff
          return true;
        }
        return base.ProcessCmdKey(ref m, keyData);
      }
    }
