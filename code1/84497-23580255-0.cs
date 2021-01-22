    protected override void WndProc(ref Message m)
    {
      if (m.Msg == <your menu id>) { ... return; }
      ...
      if (m.Msg == 0x0093 /*WM_UAHINITMENU*/ || m.Msg == 0x0117 /*WM_INITMENUPOPUP*/ || m.Msg == 0x0116 /*WM_INITMENU*/)
      {
        IntPtr shortcut = m.Msg == 0x0093 ? Marshal.ReadIntPtr(m.LParam) : m.WParam;
        // add <your menu id> to shortcut
        ...
      }
      ...
      base.WndProc(ref m);
    }
