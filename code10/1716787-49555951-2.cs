    public static readonly DependencyProperty AddressProperty =
        DependencyProperty.Register(
            nameof(Address),
            typeof(string),
            typeof(YourControl),
            new PropertyMetadata(""));
