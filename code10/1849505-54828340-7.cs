    List<Result> results = aEntries.Select(a =>
    {
        var lastB = bEntries.OrderByDescending(b => b.UpdateDate)
                         .First(b => b.PackageId == a.PackageId);
        return new Result
        {
            PackageId = a.PackageId,
            From = a.From,
            To = a.To,
            LastAction = lastB.Action,
            UpdateDate = lastB.UpdateDate
        };
    }).ToList();
