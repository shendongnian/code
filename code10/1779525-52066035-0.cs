    [HttpGet]
    public IHttpActionResult GetRFQByQuote(string number)
    {
    	var quote = db.QuoteSet.FirstOrDefault(q => q.Number == number);
    	if(quote != null)
    	{
    	    var result = quote.RFQ?.Select(x => new {
    							ID = x.ID,
    							QuoteID = x.QuoteID,
    							Signoffs = x.Signoffs }).FirstOrDefault()
    		return Ok(result);
    	}
    	else
    	{
    		return null;
    	}
    }
