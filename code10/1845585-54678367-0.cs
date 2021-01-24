    //json is your JSON string
    var deserializedTickers = JsonConvert.DeserializeObject<TickersRoot>(json);
    
    foreach(var ticker in deserializedTickers.Tickers)
    {
        // ticker.Key is "ADA/CAD" for example 
        // and in ticker.Value is all the data relating to that key
    	var symbol = ticker.Value.Symbol;
    	if (symbol != null)
    	{
    		MessageBox.Show(symbol.ToString());
    	}
    }
