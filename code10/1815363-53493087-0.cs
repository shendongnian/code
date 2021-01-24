        private double _giftSold;
    public double GiftSold
    {
        get { return _giftSold; }
        set
        {
            if (value != _giftSold)
            {
                _giftSold = value;
				CalculateRemainingBalance();
                OnPropertyChanged("GiftSold"); 
            }
        }
    }
    private double _giftUsed;
    public double GiftUsed
    {
        get { return _giftUsed; }
        set
        {
            if (value != _giftUsed)
            {
                _giftUsed = value;
					CalculateRemainingBalance();
                OnPropertyChanged("GiftUsed");
            }
        }
    }
	private double _RemainingBalance;
    public double RemainingBalance
    {
        get { return _RemainingBalance }
    }
	
	private void CalculateRemainingBalance()
	{
	_RemainingBalance = GiftSold - GiftUsed;
	 OnPropertyChanged("RemainingBalance");
	}
	
