    string s = String.Join(", ", new Func<List<string>>( () =>
    {
        List<string> list = new List<string>();
        foreach (int i in Enumerable.Range(1, 50))
            list.Add("cb" + i.ToString().PadLeft(2, '0'));
        return list;
    }).Invoke());
