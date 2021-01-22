    static string CommaQuibbling<T>(IEnumerable<T> items)
    {
        int count = items.Count();
        var quibbled = items.Select((Item, index) => new { Item, Group = (count - index - 2) > 0})
                            .GroupBy(item => item.Group, item => item.Item)
                            .Select(g => g.Key
                                ? String.Join(", ", g)
                                : String.Join(" and ", g));
        return "{" + String.Join(", ", quibbled) + "}";
    }
