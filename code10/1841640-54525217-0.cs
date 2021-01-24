    private int _currentPrice;
    public int CurrentPrice
    {
        get
        {
            return _currentPrice; 
        }
        set
        {
            if (Counter > 0) // that is when we are not using the constructor
            {
                CallPriceChanger(this);
            }
            _currentPrice = value;
            ++Counter; 
        }
    }
