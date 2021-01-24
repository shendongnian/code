        QuoteClose = new QuoteClose()
        {
            QuoteId = closeQuote.ToEntityReference(),
            Subject = "Quote Close " + DateTime.Now.ToString()
        },
        Status = new OptionSetValue(-1)
    };
    _serviceProxy.Execute(closeQuoteRequest);
