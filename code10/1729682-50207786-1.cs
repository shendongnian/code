    protected override void WndProc(ref Message m)
    {
      const int notifyParent = 528; //might be different depending on problem
      if(m.Msg == notifyParent && !this.Focused)
      {
        this.Focus();
      }
      base.WndProc(ref m);
    }
