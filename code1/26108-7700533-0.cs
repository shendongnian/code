    var xDocument = XDocument.Parse(
    @"<root>
        <f:table xmlns:f=""http://www.w3schools.com/furniture"">
            <f:name>African Coffee Table</f:name>
            <f:width>80</f:width>
            <f:length>120</f:length>
        </f:table>
      </root>");
    xDocument.StripNamespace();
    var tables = xDocument.Descendants("table");
    public static class XmlExtensions
    {
        public static void StripNamespace(this XDocument document)
        {
            if (document.Root == null)
            {
                return;
            }
            foreach (var element in document.Root.DescendantsAndSelf())
            {
                element.Name = element.Name.LocalName;
                element.ReplaceAttributes(GetAttributes(element));
            }
        }
        static IEnumerable GetAttributes(XElement xElement)
        {
            return xElement.Attributes()
                .Where(x => !x.IsNamespaceDeclaration)
                .Select(x => new XAttribute(x.Name.LocalName, x.Value));
        }
    }
