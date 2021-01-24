    var rateGroupIds = new List<int>();
    if (gardenvlist.Count() == days)
    {
        rateGroupIds.AddRange(gardenvlist.Select(x => RateGroupID));
    }
    if (oceanvlist.Count() == days)
    {
        rateGroupIds.AddRange(oceanvlist.Select(x => RateGroupID));
    }
    if (cityvlist.Count() == days)
    {
        rateGroupIds.AddRange(cityvlist.Select(x => RateGroupID));
    }
