    delegate void SetTextCallback(System.Windows.Forms.Control c, string t);
    
    private void SafeSetText(System.Windows.Forms.Control c, string t)
    {
      if (c.InvokeRequired)
      {
        SetTextCallback d = new SetTextCallback(SafeSetText);
        d.Invoke(d, new object[] { c, t });
      }
      else
      {
        c.Text = t;
      }
    }
