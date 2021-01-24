    var query = _context.CatchDetails.Where(
                    x => x.Monitoring.Client.Id == filter.CustomerId && x.Data.published >= startTimestanp
                         && x.Data.published <= endTimestanp);
    if (filter.Sentiment != Sentiments.ALL) 
    {
        query = query.Where(x => x.Sentiment_enum == filter.Sentiment);
    }
    if (filter.MonitoringId != 0)
    {
        query = query.Where(x => x.Monitoring.id == filter.MonitoringId);
    }
    
    [...]
    
    return await 
        query.Select(s => new PostValues() {
            [...]
            }).ToListAsync(cancellationToken);
