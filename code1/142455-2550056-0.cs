    private void ShowMessageBox(object sender, EventArgs e)
    {
      if (this.InvokeRequired)
      {
        lock (_lock)
        {
          EventHandler d = new EventHandler(ShowMessageBox);
          this.Invoke(d, new object[] { sender, e });
          return;
        }
      }
      else
      {
        MessageBox.Show("Show some messsage");
      }
    }
