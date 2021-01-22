    var result = mainList.SelectMany(x => x.LineOfBusinessList)
                         .SelectMany(lob => lob.Watchlists)
                         .GroupBy(wl => wl.ID)
                         .Select(g => new { 
                                WatchlistID = g.Key,
                                WatchlistName = g.First().Name,
                                ReportCount = g.Sum(item => item.ReportCount)  
                         });
