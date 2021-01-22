public static class XmlDocumentHelper
{
    public static XmlDocument FromXDocument(XDocument document)
    {
        var result = new XmlDocument();
        using (XmlReader reader = document.CreateReader())
        {
            result.Load(reader);
        }
        return result;
    }
}
So Value is set like this:  Value = XmlDocumentHelper.FromXDocument(document);
