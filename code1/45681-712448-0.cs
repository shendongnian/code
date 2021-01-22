    public static int MostFrequent(IEnumerable<int> enumerable)
    {
        var query = from it in enumerable
                     group it by it into g
                     select new {Key = g.Key, Count = g.Count()} ;
       return query.OrderByDescending(x => x.Count).First().Key;
    } 
