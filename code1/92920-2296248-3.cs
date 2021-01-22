    private static void PostProcess(Stream inStream, Stream outStream)
    {
        var settings = new XmlWriterSettings() { Indent = true, IndentChars = " " };
        using (var reader = XmlReader.Create(inStream))
        using (var writer = XmlWriter.Create(outStream, settings)) {
            while (reader.Read()) {
                switch (reader.NodeType) {
                    case XmlNodeType.Element:
                        writer.WriteStartElement(reader.Prefix, reader.Name, reader.NamespaceURI);
                        writer.WriteAttributes(reader, true);
                        
                        //
                        // check if this is the node you want, inject attributes here.
                        //
                        if (reader.IsEmptyElement) {
                            writer.WriteEndElement();
                        }
                        break;
                    case XmlNodeType.Text:
                        writer.WriteString(reader.Value);
                        break;
                    case XmlNodeType.EndElement:
                        writer.WriteFullEndElement();
                        break;
                    case XmlNodeType.XmlDeclaration:
                    case XmlNodeType.ProcessingInstruction:
                        writer.WriteProcessingInstruction(reader.Name, reader.Value);
                        break;
                    case XmlNodeType.SignificantWhitespace:
                        writer.WriteWhitespace(reader.Value);
                        break;
                }
            }
        }
    }
