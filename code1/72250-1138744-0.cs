    public static IEnumerable<string> XmlSerializeAll<T>(this IEnumerable<T> input)
    {
        foreach (T item in input)
        {
            yield return item.ToXmlString();
        }
    }
