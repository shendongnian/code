       Task.Run(async () =>
        {
            await Task.Delay(2000);
            throw new Exception("This exception will terminate the app.");
        })
        .ContinueWith(async (res) =>
        {
            if (res.IsFaulted)
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    () => throw res.Exception.InnerException);
        });
