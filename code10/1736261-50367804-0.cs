    .GroupBy(ep => new { ep.SendType, ep.Registry })
    .Select(ep => new
    {
        ep.Key.SendType,
        ep.Key.Registry,
        TotalSent = ep.Count()
    });
