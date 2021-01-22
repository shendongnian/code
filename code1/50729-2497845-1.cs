    public static string CommaQuibbling(IEnumerable<string> items)
    {
    	string[] parts = items.ToArray();
        StringBuilder result = new StringBuilder('{');
        for (int i = 0; i < parts.Length; i++)
        {
            if (i > 0)
                result.Append(i == parts.Length - 1 ? " and " : ", ");
            result.Append(parts[i]);
        }
        return result.Append('}').ToString();
    }
