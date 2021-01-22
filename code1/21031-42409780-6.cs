    string s = String.Join(", ", new Func<List<string>>( () =>
    {
        List<string> list = new List<string>();
        foreach (int i in Enumerable.Range(1, 50))
            list.Add(String.Format("cb{0:00}", i));
        return list;
    }).Invoke());
