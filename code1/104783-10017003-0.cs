    if (backgroundWorker.IsBusy)
    {
        backgroundWorker.CancelAsync();
        while (backgroundWorker.IsBusy)
        {
            Application.DoEvents();
        }
    }
