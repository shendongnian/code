    private void button1_Click(object sender, EventArgs e)
    {
      SetTextAsyncSafe("This update was made from the UI Thread by using Invoke()");
      SetTextAsyncUnsafe("This update was made directly from the background thread and can cause problems");
    }
    
    private void SetTextAsyncUnsafe(string value)
    {
      new Thread(() => SetText(value, false)).Start();
    }
    private void SetTextAsyncSafe(string value)
    {
      new Thread(() => SetText(value, true)).Start();
    }
    private void SetText(string value, bool checkInvokeRequired)
    {
      if (checkInvokeRequired) 
      {
        if (InvokeRequired) 
        {
          Invoke(new Action(() => SetText(value, checkInvokeRequired)));
          return; // early exit
        }
      }
      textBox1.Text = value;
    }
