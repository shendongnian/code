    public class QuoteCreateService : QuoteProcessor, IQuoteCreateService
    {
        [Dependency]
        protected IService_1 Service_1 { get; public set; }
        // ...
        [Dependency]
        protected IService_N Service_N; { get; public set; }
    
        public override QuoteUpdaterList QuotePipeline =>
            new QuoteUpdaterList
            {
                Service_1.DoSomething_1,
                // ...
                Service_N.DoSomething_N
            };
    
        public Quote CreateQuote(Quote quote = null) => 
            ProcessQuote(quote);
    }
