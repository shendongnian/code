    Task marker = Task.Run(() => ...);
    marker.ContinueWith(m =>
    {
        if (!m.IsFaulted)
            return;
        // Marker Faulted status indicates unhandled exceptions. Observe them.
        AggregateException e = m.Exception;
    });
