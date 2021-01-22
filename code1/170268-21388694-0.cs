    var datasource = (from n in SearchResults
    select new
    {
      PageLink = uQuery.GetNode(n.Id).NiceUrl,
      uQuery.GetNode(n.Id).Name,
      Date =    uQuery.GetNode(n.Id).GetProperty("startDate"),
      IntroText = string.IsNullOrEmpty(uQuery.GetNode(n.Id).GetProperty("introText").Value) ? string.Empty : uQuery.GetNode(n.Id).GetProperty("introText").Value,
      Image = ImageCheck(uQuery.GetNode(n.Id).GetProperty("smallImage").Value)
    }).Distinct().ToList();
