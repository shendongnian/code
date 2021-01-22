    public ViewModel()
    {
        AddPropertyDependency("Amount", "TradeValue");
        AddPropertyDependency("Price", "TradeValue");
    }
