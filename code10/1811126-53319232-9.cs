    public static class DelayedAction
    {
        public static Task RunAsync(TimeSpan delay, Action action)
        {
           return Task.Delay(delay).ContinueWith(t => action(), TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
