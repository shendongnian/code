    public List<T> ConcatMultiple<T>(this List<T> list, params[] ICollection<T> others)
    {
        List<T> results = new List<T>(list.Count + others.Sum(i => i.Count));
        results.AddRange(list);
        foreach(var l in others)
            results.AddRange(l);
        return results;
    }
