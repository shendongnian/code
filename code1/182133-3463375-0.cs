    public Bar Prop3 { get { return lazy.Value.Item1; } }
    public Bar2 Prop4 { get { return lazy.Value.Item2; } }
    private readonly Lazy<Tuple<Bar, Bar2>> lazy =
        new Lazy<Tuple<Bar, Bar2>>(LoadDetailedInformation);
    private Tuple<Bar, Bar2> LoadDetailedInformation()
    {
        ...
    }
