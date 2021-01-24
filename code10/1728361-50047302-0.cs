    var newList = Filtered.GroupBy(x => new { x.GroupName, x.PersonName }):
    var result = new MultiKeyDictionary<string, string, int>);
    foreach(var y in newList)
    {
        result.Add(y.Key.GroupName, y.Key.PersonName, y.ToList().Count));    
    }
                
