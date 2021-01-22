    public static class XElementExtensions
    {
        private static XName _nillableAttributeName = "{http://www.w3.org/2001/XMLSchema-instance}nil";
    
        public static void SetNillableElementValue(this XElement parentElement, XName elementName, object value)
        {
            parentElement.SetElementValue(elementName, value);
            parentElement.Element(elementName).MakeNillable();
        }
    
        public static XElement MakeNillable(this XElement element)
        {
            var hasNillableAttribute = element.Attribute(_nillableAttributeName) != null;
            if (string.IsNullOrEmpty(element.Value))
            {
                if (!hasNillableAttribute)
                    element.Add(new XAttribute(_nillableAttributeName, true));
            }
            else
            {
                if (hasNillableAttribute)
                    element.Attribute(_nillableAttributeName).Remove();
            }
            return element;
        }
    }
