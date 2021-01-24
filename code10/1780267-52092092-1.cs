    private readonly bool _isIndented;
    public HomeController(IOptions<MvcJsonOptions> jsonOptions, /* ... */)
    {
        _isIndented = jsonOptions.Value.SerializerSettings.Formatting == Formatting.Indented;
    }
