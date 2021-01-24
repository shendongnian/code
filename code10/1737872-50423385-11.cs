    public async Task DoWorkAsync()
    {
      foreach (var listBoxItem in visualListBox1.Items)
      {
        lblCursor.Text = "Processing.. " + listBoxItem;
    
        // Wait for signal to proceed without blocking resources
        await Task.Run(() => ExtractGroup(listBoxItem.ToString()));
      }
    }  
