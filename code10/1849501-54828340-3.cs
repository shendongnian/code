    var results = alist.Select(a =>
    {
        var lastB = blist.OrderByDescending(b => b.UpdateDate)
                         .Last(b => b.PackageId == a.PackageId);
        return new Result
        {
            PackageId = a.PackageId,
            From = a.From,
            To = a.To,
            LastAction = lastB.Action,
            UpdateDate = lastB.UpdateDate
        };
    });
