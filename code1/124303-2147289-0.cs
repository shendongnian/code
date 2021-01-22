    public RateInstrument(string ric, string tenor, string date)
    {
        Ric = ric;
        if (!string.IsNullOrEmpty(tenor))
        {
                Tenor = tenor;
        }
    
        if (!string.IsNullOrEmpty(date))
        {
            Date = ConvDate(date);
        }
    }
