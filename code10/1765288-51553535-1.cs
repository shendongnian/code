    private void AnalyzeItems(List<int> items, IProgress<double> progress)
    {
        var lastReport = DateTime.UtcNow;
        for (int itemIndex = 0; itemIndex < items.Count; itemIndex++)
        {
            // Very long running work.
            Thread.Sleep(10);
            if (DateTime.UtcNow - lastReport > TimeSpan.FromMilliseconds(500))
            {
                progress.Report((double)itemIndex * 100 / items.Count);
                lastReport = DateTime.UtcNow;
            }
        }
    }
