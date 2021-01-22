    public static class XExtensions
    {
        public static string GetAbsoluteXPath(this XElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
    
            Func<XElement, string> relativeXPath = e =>
            {
                return string.Format
                (
                    "/{0}[{1}]",
                    e.Name.LocalName, 
                    e.IndexPosition().ToString()
                );
            };
    
            var ancestors = from e in element.Ancestors()
                            select relativeXPath(e);
    
            return string.Concat(ancestors.Reverse().ToArray()) + 
                   relativeXPath(element);
        }
    
        public static int IndexPosition(this XElement element)
        {
            if (element.Parent == null)
            {
                return 0;
            }
    
            var siblings = element.Parent
                                  .Descendants(element.Name)
                                  .ToArray();
    
            int i = 0;
    
            while (siblings[i++] != element) ;
    
            return --i;
        }
    }
