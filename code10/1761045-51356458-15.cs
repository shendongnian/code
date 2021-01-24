    private async void OnLoad()
    {
        var progress = new Progress<Tuple<string, double>>();
        progress.ProgressChanged += OnWorkProgress;
        await Task.Run(() => DoWork(progress));
    }
    private void OnWorkProgress(object sender, Tuple<string, double> e)
    {
        Values.Add(e.Item1);
        NotifyPropertyChanged(nameof(Values));
        ProgressValue = e.Item2 * 100;
    }
    private void DoWork(IProgress<Tuple<string, double>> progress)
    {
        const int elementsCount = 500;
        for (int index = 0; index < elementsCount; index++)
        {
            var result = "Value_" + index;
            Thread.Sleep(10); // don't do this. Do CPU intensive work here...
            progress.Report(Tuple.Create(result, (double)index / elementsCount));
        }
    }
