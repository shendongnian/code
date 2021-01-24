    bool IsUnique<T>(IEnumerable<T> list, string propertyName)
    {
        return list.Select(x => x.GetType().GetProperty(propertyName).GetValue(x))
            .GroupBy(x => x).All(x => x.Count() == 1);
    }
