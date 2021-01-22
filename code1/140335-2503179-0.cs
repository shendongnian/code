    var oldList = GetTheStartList();
    var map = oldList.ToDictionary(x => x.Item1.Month);
    // Create an entry with 0 for every month 1-12 in this year 
    // and reduce it to just the months which don't already 
    // exist 
    var missing = 
      Enumerable.Range(1,12)
      .Where(x => !map.ContainsKey(x))
      .Select(x => Tuple.Create(new DateTime(2010, x,0),0))
    // Combine the missing list with the original list, sort by
    // month 
    var all = 
      oldList
      .Concat(missing)
      .OrderBy(x => x.Item1.Month)
      .ToList();
 
