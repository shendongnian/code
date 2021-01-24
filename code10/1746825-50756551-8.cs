    TaskScheduler.UnobservedTaskException += (sender, eventArgs) =>
    {
        eventArgs.SetObserved();
        ((AggregateException)eventArgs.Exception).Handle(ex =>
        {
            // Arriving here is BAD - means we've forgotten an exception handler around await
            // Or haven't checked for `.IsFaulted` on `.ContinueWith`
            Trace.WriteLine($"Unobserved Exception {ex.Message}");
            return true;
        });
    };
