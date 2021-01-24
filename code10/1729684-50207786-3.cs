    protected override void WndProc(ref Message m)
    {
      const int NotifyParent = 528; //might be different depending on problem
      if(m.Msg == NotifyParent && !this.Focused)
      {
        this.Focus();
      }
      base.WndProc(ref m);
    }
