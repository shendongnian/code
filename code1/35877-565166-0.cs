    private readonly Guid _ItemId
    public Guid ItemId
    {
        get { return _ItemId; }
    }
    public TransactionItem()
    {
        _ItemId = Guid.Empty;
    }
