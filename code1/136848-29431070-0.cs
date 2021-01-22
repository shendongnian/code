    /// <summary>
    /// Provides access to system time while allowing it to be set to a fixed <see cref="DateTime"/> value.
    /// </summary>
    /// <remarks>
    /// This class is thread safe.
    /// </remarks>
    public static class SystemClock
    {
        private static readonly ThreadLocal<Func<DateTime>> _getTime =
            new ThreadLocal<Func<DateTime>>(() => () => DateTime.Now);
        /// <inheritdoc cref="DateTime.Today"/>
        public static DateTime Today
        {
            get { return _getTime.Value().Date; }
        }
        /// <inheritdoc cref="DateTime.Now"/>
        public static DateTime Now
        {
            get { return _getTime.Value(); }
        }
        /// <inheritdoc cref="DateTime.UtcNow"/>
        public static DateTime UtcNow
        {
            get { return _getTime.Value().ToUniversalTime(); }
        }
        /// <summary>
        /// Sets a fixed (deterministic) time for the current thread to return by <see cref="SystemClock"/>.
        /// </summary>
        public static void Set(DateTime time)
        {
            if (time.Kind != DateTimeKind.Local)
                time = time.ToLocalTime();
            _getTime.Value = () => time;
        }
        /// <summary>
        /// Resets <see cref="SystemClock"/> to return the current <see cref="DateTime.Now"/>.
        /// </summary>
        public static void Reset()
        {
            _getTime.Value = () => DateTime.Now;
        }
    }
