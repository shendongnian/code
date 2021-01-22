    // performs a shallow copy of a given node. courtesy of Mark Fussell
    // http://blogs.msdn.com/b/mfussell/archive/2005/02/12/371546.aspx
    public static void WriteShallowNode(XmlReader reader, XmlWriter writer)
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
    // trims xml file to specified file size. does so by 
    // counting number of "victim candidates" and then iteratively
    // trimming these candidates one at a time until resultant
    // file size is just less than desired limit. does not
    // consider nested victim candidates.
    public void TrimXmlFile(string filename, long size, string trimNodeName)
    {
        long fileSize = new FileInfo(filename).Length;
        long workNodeCount = 0;
        // count number of victim elements in xml
        if (fileSize > size)
        {
            XmlReader countReader = XmlReader.Create(filename);
            for (; countReader.Read(); )
            {
                if (countReader.NodeType == XmlNodeType.Element && 
                    countReader.Name == trimNodeName)
                {
                    workNodeCount++;
                    countReader.Skip();
                }
            }
            countReader.Close();
        }
        // if greater than desired file size, and there is at least
        // one victim candidate
        string workFilename = filename+".work";
        for (; 
            fileSize > size && workNodeCount > 0; 
            fileSize = new FileInfo(filename).Length)
        {
            workNodeCount--;
            using (FileStream readFile = new FileStream(filename, FileMode.Open))
            using (FileStream writeFile = new FileStream(
                workFilename, 
                FileMode.Create))
            {
                XmlReader reader = XmlReader.Create(readFile);
                XmlWriter writer = XmlWriter.Create(writeFile);
                long j = 0;
                bool hasAlreadyRead = false;
                for (; (hasAlreadyRead) || reader.Read(); )
                {
                    // if node is a victim node
                    if (reader.NodeType == XmlNodeType.Element && 
                        reader.Name == trimNodeName)
                    {
                        // if we have not surpassed this iteration's
                        // allowance, preserve node
                        if (j < workNodeCount)
                        {
                            writer.WriteNode(reader, true);
                        }
                        j++;
                        // if we have exceeded this iteration's
                        // allowance, trim node (and whitespace)
                        if (j >= workNodeCount)
                        {
                            reader.ReadToNextSibling(trimNodeName);
                        }
                        hasAlreadyRead = true;
                    }
                    else
                    {
                        // some other xml content we should preserve
                        WriteShallowNode(reader, writer);
                        hasAlreadyRead = false;
                    }
                }
                writer.Flush();
            }
            File.Copy(workFilename, filename, true);
        }
        File.Delete(workFilename);
    }
