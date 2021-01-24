    var results = alist.Select(a =>
    {
        var b = blist.Last(x => x.PackageId == a.PackageId);
        return new Result
        {
            PackageId = a.PackageId,
            From = a.From,
            To = a.To,
            LastAction = b.Action,
            UpdateDate = b.UpdateDate
        };
    });
