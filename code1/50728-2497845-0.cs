    public static string CommaQuibbling(IEnumerable<string> items)
    {
    	string[] parts = items.ToArray();
        StringBuilder result = new StringBuilder('{');
        for (int i = 0; i < parts.Count; i++)
        {
            if (i > 0)
                result.Append(i == parts.Count - 1 ? " and " : ", ");
            result.Append(parts[i]);
        }
        return result.Append('}').ToString();
    }
