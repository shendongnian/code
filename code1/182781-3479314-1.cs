    private decimal _amount;
    
    public string FormattedAmount
    {
        get { return string.Format("{0:C}", _amount); }
    }
