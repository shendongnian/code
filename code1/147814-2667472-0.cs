    public static void Replace(this XDocument haystack, String needle, String replacement)
    {
        var query = haystack.Root
                            .DescendantsAndSelf()
                            .Where(xe => !xe.HasElements && xe.Value == needle);
        foreach (XElement item in query)
        {
            item.Value = replacement;
        }
    }
