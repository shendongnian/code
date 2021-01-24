    private static int[] NumbersFromString(string input)
    {
        var parts = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        var values = new List<int>(parts.Length);
        foreach (var part in parts)
        {
            int value;
            if (!int.TryParse(part, out value))
            {
                throw new ArgumentException("One or more values in the input string are invalid.", "input");
            }
            values.Add(value);
        }
        return values.ToArray();
    }
