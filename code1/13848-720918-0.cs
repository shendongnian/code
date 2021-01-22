    public static class XElementExtensions
    {
        public static void OrderElements(this XElement parent, params string[] orderedLocalNames)
        {            
            List<string> order = new List<string>(orderedLocalNames);            
            var orderedNodes = parent.Elements().OrderBy(e => order.IndexOf(e.Name.LocalName) >= 0? order.IndexOf(e.Name.LocalName): Int32.MaxValue);
            parent.ReplaceNodes(orderedNodes);
        }
    }
    // using the extension method before persisting xml
    this.Root.Element("parentNode").OrderElements("one", "two", "three", "four");
