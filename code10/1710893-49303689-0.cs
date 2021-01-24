    public static IEnumerable<List<string>> Split(IEnumerable<string> values)
    {
        var result = new List<List<string>>();
        foreach (var value in values)
        {
            var currentGroup = result.LastOrDefault();
            if (currentGroup?.FirstOrDefault()?.Equals(value) == true)
            {
                currentGroup.Add(value);
            }
            else
            {
                result.Add(new List<string> { value });
            }
        }
        return result;
    }
