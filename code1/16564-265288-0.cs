    public IEnumerable<int> unique(int[] ids)
    {
        List<int> l = new List<int>();
        foreach (int id in ids)
        {
            if (!l.Contains(id))
            {
                l.Add(id);
                yield return id;
            }
        }
    }
