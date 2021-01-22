    var mytask = Task.Factory.StartNew(() =>
    {
        Thread.Sleep(5000);
        return 2712;
    });
    mytask.ContinueWith(delegate
    {
        _backgroundTask.ContinueTask(() =>lblPercent.Content = mytask.Result.ToString(CultureInfo.InvariantCulture));
    });   
    
