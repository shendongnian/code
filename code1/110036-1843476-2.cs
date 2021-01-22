    public class Service 
    {
        public static MarketDataExchange GetMarketDataExchange(string ActivCode) {
        {
            int x = 65, y = 65;
            switch(ActivCode.Length)
            {
                case 1:
                    x = ActivCode[0];
                    break;
                case 2:
                    x = ActivCode[0];
                    y = ActivCode[1];
                    break;
            }
            return _table[x, y];
        }
        public static MarketDataExchange[,] _table = 
            new MarketDataExchange['Z','Z'];
        public static void InitTable()
        {
            AddItem("", MarketDataExchange.NBBO);
            AddItem("A", MarketDataExchange.AMEX);
            AddItem("B", MarketDataExchange.BSE);
            AddItem("BT", MarketDataExchange.BATS);
            AddItem("C", MarketDataExchange.NSE);
            AddItem("MW", MarketDataExchange.CHX);
            AddItem("N", MarketDataExchange.NYSE);
            AddItem("PA", MarketDataExchange.ARCA);
            AddItem("Q", MarketDataExchange.NASDAQ);
            AddItem("QD", MarketDataExchange.NASDAQ_ADF);
            AddItem("W", MarketDataExchange.CBOE);
            AddItem("X", MarketDataExchange.PHLIX);
            AddItem("Y", MarketDataExchange.DIRECTEDGE);
        }
        private static void AddItem(string s, MarketDataExchange exchange)
        {
            char x = 'A', y = 'A';
            switch(s.Length)
            {
                case 1:
                    x = s[0];
                    break;
                case 2:
                    x = s[0];
                    y = s[1];
                    break;
            }
            _table[x, y] = exchange;
        }
    }
