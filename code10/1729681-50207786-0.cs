    protected override void WndProc(ref Message m)
    {
      if(m.Msg == <magic number DPI setting> && !this.Focused)
      {
        this.Focus();
      }
      base.WndProc(ref m);
    }
