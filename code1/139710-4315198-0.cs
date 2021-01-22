    protected override bool ProcessKeyPreview(ref System.Windows.Forms.Message m)
    {
      int VK_ESCAPE = 27;
      if (m.Msg == Win32Constants.WM_KEYDOWN && (int)m.WParam == VK_ESCAPE)
      {
        // ...
      }
      return base.ProcessKeyPreview(ref m);
    }
