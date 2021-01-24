    public static IEnumerable<List<string>> Split(IEnumerable<string> values)
    {
        return values.Aggregate(
            new List<List<string>>(),
            (lists, str) =>
            {
                var currentGroup = lists.LastOrDefault();
                if (currentGroup?.FirstOrDefault()?.Equals(str) == true)
                {
                    currentGroup.Add(str);
                }
                else
                {
                    lists.Add(new List<string> { str });
                }
                return lists;
            },
            lists => lists);
    }
