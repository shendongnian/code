    private class CachedReference : IEquatable<CachedObject> {
        private readonly int _hash;
        public WeakReference Value { get; }
        public CachedReference (Object obj) {
            Value = new WeakReference(obj);
            _hash = RuntimeHelpers.GetHashCode(Value);
        }
        override int GetHashCode() => _hash;
        // If our value is garbage collected, we'll stop matching anything
        override bool Equals(CachedObject other) =>
            Value != null && ReferenceEquals(Value, other.Value);
    }
    ConcurrentDictionary<CachedReference, ReallyExpensiveInformation> cache = new ...;
    // And we use it like this
    public ReallyExpensiveInformation GetOrCompute(Object obj) =>
        return cache.GetOrAdd(new CachedReference(obj), key => ComputeExpensiveInfo(key.Value));
