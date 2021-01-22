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
        static Service()
        {
            InitTable();
        }
        public static MarketDataExchange[,] _table = 
            new MarketDataExchange['Z','Z'];
        public static void InitTable()
        {
            for (int x = 0; x < 'Z'; x++)
                for (int y = 0; y < 'Z'; y++)
                    _table[x, y] = MarketDataExchange.NONE;
            SetCell("", MarketDataExchange.NBBO);
            SetCell("A", MarketDataExchange.AMEX);
            SetCell("B", MarketDataExchange.BSE);
            SetCell("BT", MarketDataExchange.BATS);
            SetCell("C", MarketDataExchange.NSE);
            SetCell("MW", MarketDataExchange.CHX);
            SetCell("N", MarketDataExchange.NYSE);
            SetCell("PA", MarketDataExchange.ARCA);
            SetCell("Q", MarketDataExchange.NASDAQ);
            SetCell("QD", MarketDataExchange.NASDAQ_ADF);
            SetCell("W", MarketDataExchange.CBOE);
            SetCell("X", MarketDataExchange.PHLX);
            SetCell("Y", MarketDataExchange.DIRECTEDGE);
        }
        private static void SetCell(string s, MarketDataExchange exchange)
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
