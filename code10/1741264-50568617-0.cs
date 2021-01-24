    Task t = Task.Factory.StartNew(() =>
    {
        int i = 1;
        while (true)
        {
            MyLabel.Dispatcher.InvokeAsync(() => MyLabel.Content = i);
            Thread.Sleep(3000);
            i++;
        }
    });
