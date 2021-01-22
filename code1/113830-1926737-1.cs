    public static IEnumerable<XElement> FindElements(XElement d, string test)
    {
        foreach (XElement e in d.Descendants()
            .Where(p => p.Attribute("text").Value == test))
        {
            yield return e;
            if (e.Parent != null)
            {
                yield return e.Parent;
            }
        }
    }
