    IEnumerable<string> tweets, keywords;
    var x = tweets.Select(t => new
                               {
                                   Tweet = t,
                                   Keywords = keywords.Where(k => k.Split(' ')
                                                                   .All(t.Contains))
                                                      .ToArray()
                               });
