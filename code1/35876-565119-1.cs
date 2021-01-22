    public Guid ItemId
    {
        get;
        private set; // can omit as of C# 6 
    }
    public TransactionItem()
    {
        this.ItemId = Guid.Empty;
    }
