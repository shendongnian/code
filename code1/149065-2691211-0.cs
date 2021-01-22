    private readonly List<SomeObject> _budget;
    public ReadOnlyCollection<SomeObject> Budget
    {
        get
        {
            return _budget.AsReadOnly();
        }
    }
