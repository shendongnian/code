    public static string ConcatenateTextNodes(
        this IEnumerable<XElement> elements)
    {
        string values = elements.Select(x => x.Value).ToArray();
        // You could parameterise the delimiter here if you wanted
        return string.Join(" ", values);
    }
