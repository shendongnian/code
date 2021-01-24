    static async Task MainAsync()
    {
        ExchangeBinanceAPI b = new ExchangeBinanceAPI();
        using (var socket = b.GetTickersWebSocket((tickers) =>
        {
            Console.WriteLine("{0} tickers, first: {1}", tickers.Count, tickers.First());
        }))
        {
            // code continues here
            Console.WriteLine("Press ENTER to shutdown.");
            Console.ReadLine();
        }
    }
