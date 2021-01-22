    public static TList GetSelectedRandom<TList>(this TList list, int count)
           where TList : IList, new()
    {
        var r = new Random();
        var rList = new TList();
        while (count > 0)
        {
            var n = r.Next(0, list.Count);
            var e = list[n];
            rList.Add(e);
            list.RemoveAt(n);
            count--;
        }
        return rList;
    }
