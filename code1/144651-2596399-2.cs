    private static bool _initialized;
    public static bool Initialized
    {
        private set
        {
            _initialized = value;
        }
        get
        {
            return _initialized;
        }
    }
