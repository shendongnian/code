    public static class XmlLinq
    {
      public static void Sort(this XElement source, bool sortAttributes = true)
      {
         if (source == null)
            throw new ArgumentNullException("source");
         if (sortAttributes)
            source.SortAttributes();
         List<XElement> sortedChildren = source.Elements().OrderBy(e => e.Name.ToString()).ToList();
         source.RemoveNodes();
         sortedChildren.ForEach(c => source.Add(c));
         sortedChildren.ForEach(c => c.Sort());
      }
      public static void SortAttributes(this XElement source)
      {
         if (source == null)
            throw new ArgumentNullException("source");
         List<XAttribute> sortedAttributes = source.Attributes().OrderBy(a => a.ToString()).ToList();
         sortedAttributes.ForEach(a => a.Remove());
         sortedAttributes.ForEach(a => source.Add(a));
      }
    }
