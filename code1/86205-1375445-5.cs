    public ActionResult finaliseQuote(string quoteid)
    {
        var info = new QuoteInfo(
                      (from q in quote.All()
                       where q.quoteid == quoteid
                       select q).SingleOrDefault()
                   );
        var parts = new QuoteParts(
                      (from qi in quoteItem.All()
                       where qi.quote_id == quoteid
                       select qi).SingleOrDefault()
                   );
        var model = new QuoteViewModel { 
                            QuoteId = quoteid,
                            Info = info,
                            Parts = parts 
                        };
        return View(model);
    }
