    async void OnButtonClick(object sender, RoutedEventArgs e)
    {
        var cts = new CancellationTokenSource();
        void OnCancel(object _, RoutedEventArgs __) => cts.Cancel();
        CancelButton.Click += OnCancel;
        try
        {
            await Task.Delay(TimeSpan.FromSeconds(2), cts.Token);
            // fire first event
            await Task.Delay(TimeSpan.FromSeconds(2), cts.Token);
            // fire second event
            await Task.Delay(TimeSpan.FromSeconds(2), cts.Token);
            // stop the timer (whatever it means)
        }
        catch (TaskCanceledException)
        {
            // handle cancelled
        }
        finally
        {
            CancelButton.Click -= OnCancel;
        }
    }
