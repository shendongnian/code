    var results = from q in quotes
                  group q by new { q.Symbol, q.TimeStamp.Date } into c
                  select new TableQuote()
                  {
                      Symbol = c.Key.Symbol,
                      TimeStamp = c.Min(ct => ct.TimeStamp),
                      Quote = c.OrderBy(ct => ct.TimeStamp).First().Quote
                  };
