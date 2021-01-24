    List<Result> = aEntries.Join(bEntries, 
        a => a.PackageId, 
        b => b.PackageId,
        (a, b) => new Result()
        {
            PackageId = a.PackageId,
            To = a.To,
            From = a.From,
            LastAction = b.Action,
            UpdateDate = b.UpdateDate
        })
        .GroupBy(r => r.PackageId)
        .Select(g => g.OrderByDescending(r => r.UpdateDate).First()).ToList();
