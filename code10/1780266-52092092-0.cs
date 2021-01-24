    private readonly MvcJsonOptions _jsonOptions;
    public HomeController(IOptions<MvcJsonOptions> jsonOptions, /* ... */)
    {
        _jsonOptions = jsonOptions.Value;
    }
    // ...
    public bool GetIsIdented() =>
        _jsonOptions.SerializerSettings.Formatting == Formatting.Indented;
