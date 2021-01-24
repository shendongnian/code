    private void OnTimerElapsed(object state)
    {
        lock (Model.SyncRoot)
        {
            Update();
        }
        try {
            if (App.IsAppActive()) {
                Device.BeginInvokeOnMainThread(() => Model.InvalidatePlot(true));
            } else {
                timer.Dispose();
            }
        } catch {
        }
    }
