    //Just some helper method
    public static IEnumerable<TKey[]> GetPaths<TKey, TDictImpl>(this IDictionary<TKey, TDictImpl> dict) where TDictImpl : IEnumerable<TKey>
    {
        var watchlist = new List<TKey>();
        var outlist = new List<List<TKey>>();
        GetPaths(dict, dict.Keys.First(), watchlist, outlist, new List<TKey> { dict.Keys.First() });
        return outlist.Select((l) => l.ToArray());
    }
    private static void GetPaths<TKey, TDictImpl>(this IDictionary<TKey, TDictImpl> dict, TKey parent, List<TKey> watchlist, List<List<TKey>> outlist, List<TKey> current) where TDictImpl : IEnumerable<TKey>
    {
        //Try to get our child from the dict
        if (!dict.TryGetValue(parent, out TDictImpl subs))
        {
            //No child found, no further navigation needs to be done
            return;
        }
        foreach (var it in subs)
        {
            //Simple check to make sure we do not end in some endless loop
            if (watchlist.Contains(it))
            {
                throw new FormatException($"The key {it.ToString()} was attempted to be traversed a second time in {parent.ToString()}.");
            }
            else
            {
                watchlist.Add(it);
            }
            //Add everything to our outlist
            var tmp = current.Concat(new TKey[] { it }).ToList();
            outlist.Add(tmp);
            //Proceed with possible childnodes
            GetPaths(dict, it, watchlist, outlist, tmp);
        }
    }
