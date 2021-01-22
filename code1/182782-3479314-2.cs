    private decimal? _amount;
    public string FormattedAmount
    {
        get
        {
             return _amount == null ? "null" : string.Format("{0:C}", _amount.Value);
        }
    }  
