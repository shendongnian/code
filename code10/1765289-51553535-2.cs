    private double _currentProgress;
    public double CurrentProgress {
        get => _currentProgress;
        set
        {
            _currentProgress = value;
            NotifyPropertyChanged();
        }
    }
    // Captured event of loading screen, clicking a button or whatever.
    private async void OnLoad(object obj)
    {
        var progress = new Progress<double>();
        progress.ProgressChanged += (sender, p) => CurrentProgress = p;
        await Task.Run(() => AnalyzeItems(Enumerable.Range(0, 5000).ToList(), progress));
    }
    private void AnalyzeItems(List<int> items, IProgress<double> progress)
    {
        for (int itemIndex = 0; itemIndex < items.Count; itemIndex++)
        {
            // Very long running CPU work.
            // ...
            progress.Report((double)itemIndex * 100 / items.Count);
        }
    }
