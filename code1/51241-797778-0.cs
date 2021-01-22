    private static int? AsNullableInt(string s)
    {
        int? asNullableInt = null;
        int asInt;
        if (int.TryParse(s, out asInt))
        {
            asNullableInt = asInt;
        }
        return asNullableInt;
    }
    // Example usage...
    int[] ints = str.Split(',')
        .Select(s => AsNullableInt(s))
        .Where(s => s.HasValue)
        .Select(s => s.Value)
        .ToArray();
