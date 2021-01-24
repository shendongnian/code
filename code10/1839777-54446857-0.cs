    public static int Visit(int months)
    {
        var values = new List<int?> {1, 2, 4, 6, 9, 12, 15, 18, 24, 30, 36, 48, 60};
        return (values.Select((v, i) => new {value = v, index = i})
            .FirstOrDefault(i => months <= i.value)?.index ?? values.Count) + 1;
    }
