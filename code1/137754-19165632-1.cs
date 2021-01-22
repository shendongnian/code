    public static IEnumerable<XElement> ElementsNamed(this XmlReader reader, string elementName)
    {
        reader.MoveToContent(); // will not advance reader if already on a content node; if successful, ReadState is Interactive
        reader.Read();          // this is needed, even with MoveToContent and ReadState.Interactive
        while(!reader.EOF && reader.ReadState == ReadState.Interactive)
        {
            if(reader.NodeType == XmlNodeType.Element && reader.Name.Equals(elementName))
            {
                 // this advances the reader...so it's either XNode.ReadFrom() or reader.Read(), but not both
                 var matchedElement = XNode.ReadFrom(reader) as XElement;
                 if(matchedElement != null)
                     yield return matchedElement;
            }
            else
                reader.Read();
        }
    }
