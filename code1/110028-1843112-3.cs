    public static MarketDataExchange GetValue(string input)
    {
        switch (input.Length)
        {
            case 0: return MarketDataExchange.NBBO;
            case 1: return (MarketDataExchange)input[0];
            case 2: return (MarketDataExchange)(input[0] << 8 | input[1]);
            default: return MarketDataExchange.None;
        }
    }
