    var table = DataContext.Set<SearchResults>();
    IQuerable<SearchResults> query = null;
    foreach(var y in serviceSuburbList)
    {
        var temp = table.Where(x => x.ServiceId == y.ServiceId && x.SuburbId == y.SuburbId);
        query = query == null ? temp : query.Union(temp);
    }
    
    var srtList = query.ToList();
