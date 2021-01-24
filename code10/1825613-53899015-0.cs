      public static void SetFutureNotification(string notificationText, DateTime notificationDateTime, Action<string> notificationAction)
    {
        CancelNotification();
        _cts = new CancellationTokenSource();
        var cts = _cts; // I'm local cts and will be captured by one task only
        Task.Run(async () =>
        {
            while (!cts.Token.IsCancellationRequested)
            {
                await Task.Delay(1000, cts.Token);
                if (DateTime.Now > notificationDateTime)
                {
                    notificationAction?.Invoke(notificationText);
                    cts.Cancel();
                }
            }
        }, cts.Token);
    }
