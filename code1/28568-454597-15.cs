    public static class XExtensions
    {
        /// <summary>
        /// Get the absolute XPath to a given XElement
        /// (e.g. "/people/person[6]/name[0]/last[0]").
        /// </summary>
        public static string GetAbsoluteXPath(this XElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
    
            Func<XElement, string> relativeXPath = e =>
            {
                int index = e.IndexPosition();
                string name = e.Name.LocalName;
    
                // If the element is the root, no index is required
    
                return (index == -1) ? "/" + name : string.Format
                (
                    "/{0}[{1}]",
                    name, 
                    index.ToString()
                );
            };
    
            var ancestors = from e in element.Ancestors()
                            select relativeXPath(e);
    
            return string.Concat(ancestors.Reverse().ToArray()) + 
                   relativeXPath(element);
        }
    
        /// <summary>
        /// Get the index of the given XElement relative to its
        /// siblings with identical names. If the given element is
        /// the root, -1 is returned.
        /// </summary>
        /// <param name="element">
        /// The element to get the index of.
        /// </param>
        public static int IndexPosition(this XElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            if (element.Parent == null)
            {
                return -1;
            }
    
            var siblings = element.Parent
                           .Descendants(element.Name)
                           .Where(decendent => decendent.Parent == element.Parent)
                           .ToArray();
    
            int i = 0;
    
            while (siblings[i++] != element) ;
    
            return i;
        }
    }
