    /// <summary>
    /// Publishes a message on the UI thread.
    /// </summary>
    /// <param name="eventAggregator">The event aggregator.</param>
    /// <param name = "message">The message instance.</param>
    public static void PublishOnUIThread(this IEventAggregator eventAggregator, object message) {
        eventAggregator.Publish(message, Execute.OnUIThread);
    }
