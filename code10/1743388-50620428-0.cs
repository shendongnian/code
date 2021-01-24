    IEnumerable<bool> CompareAll<T>(IEnumerable<IEnumerable<T>> source)
    {
        var lists = source.ToList();
        var firstList = lists[0];
        var otherLists = lists.Skip(1).ToList();
        foreach(var t1 in firstList)
        {
            yield return otherlists.All(tn => tn.Equals(t1));
        }
    }
