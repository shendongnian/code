    try
    {
        Dispatcher.Invoke((Action)OnShutDown, DispatcherPriority.Send, CancellationToken.None, TimeSpan.FromMilliseconds(300));
        succeeded = true;
    }
    catch (TimeoutException)
    {
    }
