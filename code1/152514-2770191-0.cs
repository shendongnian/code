    public static MyClass DoSomething()
    {
        if (_cachedValue == null || DateTime.Now - _created > _keepFor)
        {
            lock (_lock)
            {
                if (_cachedValue == null || DateTime.Now - _created > _keepFor)
                {
                    _cachedValue = new MyClass();
                    _created = DateTime.Now;
                }
            }
        }
        return _cachedValue;
    }
    private static readonly object _lock = new object();
    private static readonly TimeSpan _keepFor = TimeSpan.FromMinutes(15);
    private static DateTime _created;
    private static MyClass _cachedValue;
