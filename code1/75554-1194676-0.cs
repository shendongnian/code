    for (i = 0; i < count; i++)
    {
        ... do analysis ...
        worker.ReportProgress((100 * i) / count);
    }
    private void MyWorker_ProgressChanged(object sender,
        ProgressChangedEventArgs e)
    {
        taskProgressBar.Value = Math.Min(e.ProgressPercentage, 100);
    }
