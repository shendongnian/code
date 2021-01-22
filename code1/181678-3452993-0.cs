    private void DispalyMessage(byte[] bytes)
    {
      if (this.InvokeRequired)
      {
        lock (_lock)
        {
          EventHandler d = new EventHandler(DispalyMessage);
          this.Invoke(d, new object[] { bytes });
          return;
        }
      }
      else
      {
        //do something with the data
      }
    }
