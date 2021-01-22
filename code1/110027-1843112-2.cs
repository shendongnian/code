    unsafe static MarketDataExchange GetValue(string input)
    {
        if (input.Length == 1)
            return (MarketDataExchange)(input[0]);
        fixed (char* buffer = input)
            return (MarketDataExchange)(buffer[0] << 8 | buffer[1]);
    }
---
    public enum MarketDataExchange
    {
        NBBO = 0x00, //
        AMEX = 0x41, //A
        BSE = 0x42, //B
        BATS = 0x4254, //BT
        NSE = 0x43, //C
        CHX = 0x4D57, //MW
        NYSE = 0x4E, //N
        ARCA = 0x5041, //PA
        NASDAQ = 0x51, //Q
        NASDAQ_ADF = 0x5144, //QD
        CBOE = 0x57, //W
        PHLX = 0x58, //X
        DIRECTEDGE = 0x59, //Y
        None = -1
    }
