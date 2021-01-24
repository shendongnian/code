    public async Task DoSomethingAsync(...)
    {
      private static AsyncManualResetEvent mre = new AsyncManualResetEvent(false, true);
      foreach (var listBoxItem in visualListBox1.Items)
      {
        lblCursor.Text = "Processing.. " + listBoxItem;
        Thread t = new Thread(() => ExtractGroup(listBoxItem.ToString()));
        t.IsBackground = false; 
        t.Name = "Group Scrapper";
        t.Start();
    
        // Wait for signal to proceed without blocking resources
        await mre.WaitAsync();
      }
    }
    
    private void ExtractGroup(string groupName)
    {
      // Do something ...
    
      // Signal handle to release all waiting threads (makes them continue). Subsequent calls to Set() or WaitOne() won't show effects until Rest() was called
      mre.Set();
    
      // Reset handle to make future call of WaitOne() wait again.
      mre.Reset();
    }
