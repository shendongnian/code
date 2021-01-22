    static public IList<T[]> GetChunks<T>(this IEnumerable<T> source, int batchsize)
    {
        IList<T[]> result = null;
        if (source != null && batchsize > 0)
        {
            var list = source as List<T> ?? source.ToList();
            if (list.Count > 0)
            {
                result = new List<T[]>();
                for (var index = 0; index < list.Count; index += batchsize)
                {
                    var rangesize = Math.Min(batchsize, list.Count - index);
                    result.Add(list.GetRange(index, rangesize).ToArray());
                }
            }
        }
        return result ?? Enumerable.Empty<T[]>().ToList();
    }
    static public void TestGetChunks()
    {
        var ids = Enumerable.Range(1, 163).Select(i => i.ToString());
        foreach (var chunk in ids.GetChunks(20))
        {
            Console.WriteLine("[{0}]", String.Join(",", chunk));
        }
    }
