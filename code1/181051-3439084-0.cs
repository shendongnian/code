    public void UpdateLabelText(String value)
    {
      if (_Form.InvokeRequired)
      {
        try { _Form.BeginInvoke(new StringParameterDelegate(UpdateLabelText), new object[] { value }); }
        catch { ;}
        return;
      }
    
      foreach (Control ctrl in _Form.Controls.Find("labelName", true))
      {
        ((Label)ctrl).Text = value;
        break; // Controls have unique names
      }
    }
