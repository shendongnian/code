    public List<int> GetFirstNElements(List<int> list, int n)
    {
        n = Math.Min(n, list.Count);
        return list.GetRange(0, n);
    }
