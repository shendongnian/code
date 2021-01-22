    public static int MostFrequent(IEnumerable<int> enumerable)
    {
        return (from it in enumerable
                     group it by it into g
                     select new {Key = g.Key, Count = g.Count()}).OrderByDescending(x => x.Count).First().Key;
                    
    }
