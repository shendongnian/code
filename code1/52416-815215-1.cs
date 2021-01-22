    private void timer_Tick(object sender, EventArgs e)
    {
      if (!backgroundWorker.IsBusy)
        backgroundWorker.RunWorkerAsync();
    }
