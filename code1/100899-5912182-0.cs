    protected override void WndProc(ref Message m)
    {
      if (m.Msg == CM_MARK) {
        if (this.ActiveControl is TextBox) {
          ((TextBox)this.ActiveControl).SelectAll();
        }
      }
      base.WndProc(ref m);
    }//end sub.
