    if (!Dispatcher.CheckAccess())
    {
        Dispatcher.Invoke(() =>
        {
            lblStatus.Content = $"{string.Format("{0:0.##}", percentage)}%";
            progressBar.Value = int.Parse(Math.Truncate(percentage).ToString());
        });
    }
    else
    {
        lblStatus.Content = $"{string.Format("{0:0.##}", percentage)}%";
        progressBar.Value = int.Parse(Math.Truncate(percentage).ToString());
    }
