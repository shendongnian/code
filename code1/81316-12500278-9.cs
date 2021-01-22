    // performs a shallow copy of a given node. courtesy of Mark Fussell
    // http://blogs.msdn.com/b/mfussell/archive/2005/02/12/371546.aspx
    public static void WriteShallowNode(this XmlWriter writer, XmlReader reader)
    {
        switch (reader.NodeType)
        {
            case XmlNodeType.Element:
                writer.WriteStartElement(
                    reader.Prefix, 
                    reader.LocalName, 
                    reader.NamespaceURI);
                writer.WriteAttributes(reader, true);
                if (reader.IsEmptyElement)
                {
                    writer.WriteEndElement();
                }
                break;
            case XmlNodeType.Text: writer.WriteString(reader.Value); break;
            case XmlNodeType.Whitespace:
            case XmlNodeType.SignificantWhitespace:
                writer.WriteWhitespace(reader.Value);
                break;
            case XmlNodeType.CDATA: writer.WriteCData(reader.Value); break;
            case XmlNodeType.EntityReference: 
                writer.WriteEntityRef(reader.Name); 
                break;
            case XmlNodeType.XmlDeclaration:
            case XmlNodeType.ProcessingInstruction:
                writer.WriteProcessingInstruction(reader.Name, reader.Value);
                break;
            case XmlNodeType.DocumentType:
                writer.WriteDocType(
                    reader.Name, 
                    reader.GetAttribute("PUBLIC"), 
                    reader.GetAttribute("SYSTEM"), 
                    reader.Value);
                break;
            case XmlNodeType.Comment: writer.WriteComment(reader.Value); break;
            case XmlNodeType.EndElement: writer.WriteFullEndElement(); break;
        }
    }
