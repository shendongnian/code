    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      switch (e.CloseReason)
      {
        case CloseReason.UserClosing:
          e.Cancel = true;
          break;
      }
      base.OnFormClosing(e);
    }
