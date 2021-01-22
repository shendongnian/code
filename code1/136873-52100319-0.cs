    public static class Clock
    {
        private static Func<DateTime> _utcNow = () => DateTime.UtcNow;
        static AsyncLocal<Func<DateTime>> _override = new AsyncLocal<Func<DateTime>>();
        public static DateTime UtcNow => (_override.Value ?? _utcNow)();
        public static void Set(Func<DateTime> func)
        {
            _override.Value = func;
        }
        public static void Reset()
        {
            _override.Value = null;
        }
    }
