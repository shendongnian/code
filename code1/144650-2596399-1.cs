    private static bool _initialized = false;
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
