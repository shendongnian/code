    string s = String.Join(", ", new Func<List<string>>( () =>
    {
        List<string> list = new List<string>();
        for (int i = 1; i <= 50; i++)
            list.Add("cb" + i.ToString().PadLeft(2, '0'));
        return list;
    }).Invoke());
