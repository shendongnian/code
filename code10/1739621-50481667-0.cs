    public static void Main(string[] args)
    {
        // Would not block the thread.
        Task t = MainAsync();
        
        // Only if you need. Would not block the thread too.
        t.ContinueWith(()=> { code block that will run after MainAsync() });
    
        // create a web socket connection to Binance. Note you can Dispose the socket anytime to shut it down.
        // the web socket will handle disconnects and attempt to re-connect automatically.
        ExchangeBinanceAPI b = new ExchangeBinanceAPI();
        using (var socket = b.GetTickersWebSocket((tickers) =>
        {
            Console.WriteLine("{0} tickers, first: {1}", tickers.Count, tickers.First());
        }))
        {
            Console.WriteLine("Press ENTER to shutdown.");
            Console.ReadLine();
        }
    }
