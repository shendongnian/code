    Task.Run(() =>
    {
        if (System.Windows.Application.Current.Dispatcher.Thread == Thread.CurrentThread)
        {
            // breakpoint bot hit in WPF
        }
    });
