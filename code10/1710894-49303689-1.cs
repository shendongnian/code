    public static IEnumerable<List<string>> Split(IEnumerable<string> values)
    {
        var currentValue = default(string);
        var group = (List<string>)null;
        foreach (var value in values)
        {
            if (group == null)
            {
                currentValue = value;
                group = new List<string> { value };
            }
            else if (currentValue.Equals(value))
            {
                group.Add(value);
            }
            else
            {
                yield return group;
                currentValue = value;
                group = new List<string> { value };
            }
        }
        if (group != null)
        {
            yield return group;
        }
    }
