    private static List<int> _intItems;
    public static List<int> IntItems
    {
        get => _intItems ?? (_intItems = new List<int>());
        set => _intItems = value;
    }
