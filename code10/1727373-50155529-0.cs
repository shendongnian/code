    Task marker = Task.Run(() => ...);
    marker.ContinueWith(m =>
    {
        if (!m.IsFaulted)
            return;
        // Observe exceptions.
        AggregateException e = m.Exception;
    });
