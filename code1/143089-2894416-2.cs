    public static class SyncContextExtensions
    {
        public static void Post(this SynchronizationContext context, TimeSpan delay, Action action)
        {
            System.Threading.Timer timer = null;
            timer = new System.Threading.Timer(
                (ignore) =>
                {
                    timer.Dispose();
                    context.Post(ignore2 => action(), null);
                }, null, delay, TimeSpan.FromMilliseconds(-1));
        }
    }
