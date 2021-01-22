    public static class UICallbackTimer
    {
        public static void DelayExecution(TimeSpan delay, Action action)
        {
            System.Threading.Timer timer = null;
            SynchronizationContext context = SynchronizationContext.Current;
            timer = new System.Threading.Timer(
                (ignore) =>
                {
                    timer.Dispose();
                    context.Post(ignore2 => action(), null);
                }, null, delay, TimeSpan.FromMilliseconds(-1));
        }
    }
