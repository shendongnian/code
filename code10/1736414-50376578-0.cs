    private static readonly Throttled<bool> ThrottledIsRaining =
        new Throttled<bool>(ExternalService.IsRaining, 1000);
    public static bool IsRaining()
    {
        bool cachedIsRaining = ThrottledIsRaining.Value;
        // This extra bit satisfies my special case - bypass the cache while it's raining
        if (!cachedIsRaining) return false;
        return ThrottledIsRaining.ForceGetUpdatedValue();
    }
----------
    /// <summary>Similar to <see cref="Lazy{T}"/>. Wraps an expensive getter
    /// for a value by caching the result and only invoking the supplied getter
    /// to update the value if the specified cache expiry time has elapsed.</summary>
    /// <typeparam name="T">The type of underlying value.</typeparam>
    public class Throttled<T>
    {
        #region Private Fields
        /// <summary>The time (in milliseconds) we must to cache the value after
        /// it has been retrieved.</summary>
        private readonly int _cacheTime;
        /// <summary>Prevent multiple threads from updating the value simultaneously.</summary>
        private readonly object _updateLock = new object();
        /// <summary>The function used to retrieve the underlying value.</summary>
        private readonly Func<T> _getValue;
        /// <summary>The cached result from the last time the underlying value was retrieved.</summary>
        private T _cachedValue;
        /// <summary>The last time the value was retrieved</summary>
        private volatile int _lastRetrieved;
        #endregion Private Fields
        /// <summary>Get the underlying value, updating the result if the cache has expired.</summary>
        public T Value
        {
            get
            {
                int now = Environment.TickCount;
                // If the cached value has expired, update it
                if (unchecked(now - _lastRetrieved) > _cacheTime)
                {
                    lock (_updateLock)
                    {
                        // Upon acquiring the lock, ensure another thread didn't update it first.
                        if (unchecked(now - _lastRetrieved) > _cacheTime)
                            return ForceGetUpdatedValue();
                    }
                }
                return _cachedValue;
            }
        }
        /// <summary>Construct a new throttled value getter.</summary>
        /// <param name="getValue">The function used to retrieve the underlying value.</param>
        /// <param name="cacheTime">The time (in milliseconds) we must to cache the value after
        /// it has been retrieved</param>
        public Throttled(Func<T> getValue, int cacheTime)
        {
            _getValue = getValue;
            _cacheTime = cacheTime;
            _lastRetrieved = unchecked(Environment.TickCount - cacheTime);
        }
        /// <summary>Retrieve the current value, regardless of whether
        /// the current cached value has expired.</summary>
        public T ForceGetUpdatedValue()
        {
            _cachedValue = _getValue();
            _lastRetrieved = Environment.TickCount;
            return _cachedValue;
        }
        /// <summary>Allows instances of this class to be accessed like a normal
        /// <typeparamref name="T"/> identifier.</summary>
        public static explicit operator T(Throttled<T> t) => t.Value;
    }
