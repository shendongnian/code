    CloseQuoteRequest closeQuoteRequest = new CloseQuoteRequest()
    {
        QuoteClose = new QuoteClose()
        {
            QuoteId = quote.ToEntityReference(),
            Subject = "Quote Close " + DateTime.Now.ToString(),
        }.ToEntity<Entity>(),
        Status = new OptionSetValue(-1),
        RequestName = "CloseQuote",
    };
    Service.Execute(closeQuoteRequest);
