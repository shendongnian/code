    private void StopTimer()
    {
        if (TmrCount != null)
        {
            TmrCount.Stop();
            TmrCount.Tick -= TmrCount_Tick;
            TmrCount.Dispose();
            TmrCount = null;
        }
    }
