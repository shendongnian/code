    private static void PipeXMLIntoWriter(XmlWriter xw, string xml)
    {
        byte[] dat = new System.Text.UTF8Encoding().GetBytes(xml);
        MemoryStream m = new MemoryStream();
        m.Write(dat, 0, dat.Length);
        m.Seek(0, SeekOrigin.Begin);
        XmlReader r = XmlReader.Create(m);
        while (r.Read())
        {
            switch (r.NodeType)
            {
                case XmlNodeType.Element:
                    xw.WriteStartElement(r.Name);
                    if (r.HasAttributes)
                    {
                        for (int i = 0; i < r.AttributeCount; i++)
                        {
                            r.MoveToAttribute(i);
                            xw.WriteAttributeString(r.Name, r.Value);
                        }
                    }
                    if (r.IsEmptyElement)
                    {
                        xw.WriteEndElement();
                    }
                    break;
                case XmlNodeType.EndElement:
                    xw.WriteEndElement();
                    break;
                case XmlNodeType.Text:
                    xw.WriteString(r.Value);
                    break;
                default:
                    throw new Exception("Unrecognized node type: " + r.NodeType);
            }
        }
    }
