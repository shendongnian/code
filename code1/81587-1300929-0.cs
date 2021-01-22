    public string Fee
    {
        get; private set;
    }
    
    public string Receipt
    {
        get; private set;
    }
    
    public MyValue(string fee, string receipt) : this()
    {
        this.Fee = int.Parse(fee).ToString();
        this.Receipt = receipt;
    }
