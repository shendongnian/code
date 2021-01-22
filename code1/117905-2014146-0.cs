    //Maps allowed tags to allowed attributes for the tags.
    static readonly Dictionary<string, string[]> AllowedTags = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase) {
        { "b",    new string[0] },
        { "img",  new string[] { "src", "alt" } },
        //...
    };
    static XElement CleanElement(XElement dirtyElement) {
        return new XElement(dirtyElem.Name,
            dirtyElement.Elements
                .Where(e => AllowedTags.ContainsKey(e.Name))
                .Select<XElement, XElement>(CleanElement)
                .Concat(
                    dirtyElement.Attributes
                        .Where(a => AllowedTags[dirtyElem.Name].Contains(a.Name, StringComparer.OrdinalIgnoreCase))
                );
    }
