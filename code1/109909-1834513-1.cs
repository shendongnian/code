    public bool PreFilterMessage(ref Message m)
    {
      FilterMessage callback = FilterMessageCallback;
      if (callback != null)
      {
        bool handled = false;
        callback(m.HWnd, m.Msg, m.WParam, m.LParam, ref handled);
        return handled;
      }
      return false;
    }
