    var table = DataContext.Set<SearchResults>();
    IQuerable<SearchResults> query = null;
    foreach(var item in serviceSuburbList)
    {
        var temp = table.Where(x => x.ServiceId == item.ServiceId && x.SuburbId == item.SuburbId);
        query = query == null ? temp : query.Union(temp);
    }
    
    var srtList = query.ToList();
