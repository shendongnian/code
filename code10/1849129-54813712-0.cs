    public List<String> ParallelSort()
    {
        var result = new List<string>(plusLIST.Count + minusLIST.Count);
        var t1 = Task.Run(() => plusLIST.AsParallel().OrderByDescending(i => int.Parse(i.Split(',')[0])));
        var t2 = Task.Run(() => minusLIST.AsParallel().OrderBy(i => int.Parse(i.Split(',')[0].TrimStart('-'))));
        Task.WaitAll(t1, t2);
        result.AddRange(t1.Result);
        result.AddRange(t2.Result);
        return result;
    }
