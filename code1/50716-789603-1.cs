    public static string CommaQuibbling(IEnumerable<string> items)
    {
        List<String> list = new List<string>(items);
        if (list.Count == 0) { return "{}"; }
        if (list.Count == 1) { return "{" + list[0] + "}"; }
        String[] initial = list.GetRange(0, list.Count - 1).ToArray();
        return "{" + String.Join(", ", initial) + " and " + list[list.Count - 1] + "}";
    }
