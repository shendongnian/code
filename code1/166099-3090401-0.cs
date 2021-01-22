    void OnStatusMessage(string s)
    {
      // might be coming from a different thread
      if (txtStatus.InvokeRequired)
      {
        this.BeginInvoke(new MethodInvoker(delegate()
        {
          OnStatusMessage(s);
        }));
      }
      else
      {
        StatusBox.Text += s + "\r\n";
        StatusBox.SelectionStart = txtStatus.TextLength;
        StatusBox.ScrollToCaret();
      }
    }
