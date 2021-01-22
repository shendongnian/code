    enum MarketDataExchange
    {
        NONE,
        NBBO = 371857150,
        AMEX = 372029405,
        BSE = 372029408,
        BATS = -1850320644,
        NSE = 372029407,
        CHX = -284236702,
        NYSE = 372029412,
        ARCA = -734575383,
        NASDAQ = 372029421,
        NASDAQ_ADF = -1137859911,
        CBOE = 372029419,
        PHLX = 372029430,
        DIRECTEDGE = 372029429
    }
    
    public static MarketDataExchange GetMarketDataExchange(string ActivCode)
    {
        if (ActivCode == null) return MarketDataExchange.NONE;
    
        return (MarketDataExchange)ActivCode.GetHashCode();
    }
