    public void ShowMessageBox()
    {
      var thread = new Thread(
        () =>
        {
          MessageBox.Show(...);
        });
      thread.Start();
    }
