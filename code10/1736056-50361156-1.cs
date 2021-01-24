    Task.Run(async () =>
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, new DispatchedHandler(FirstTask));
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, new DispatchedHandler(SecondTask));
            });
    private async void FirstTask()
    {
        await Task.Delay(2000);
        textnew1.Text = "Dispatched";
    }
    private async void SecondTask()
    {
        await Task.Delay(2000);
        textnew2.Text = "BackgroundTask";
    }
