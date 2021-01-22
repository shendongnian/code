    protected override void OnKeyDown(KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        if (Parent != null)
        {
          Control nextControl = Parent.GetNextControl(this, true);
          if (nextControl != null)
          {
            nextControl.Focus();
            return;
          }
        }
      }
      base.OnKeyDown(e);
    }
