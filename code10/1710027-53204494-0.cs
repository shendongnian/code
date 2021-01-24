    using (var stringWriter = new Utf8StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true, IndentChars = "\t", NewLineChars = "\r\n", NewLineHandling = NewLineHandling.Replace }))
                {                    
                    xmlSerializer.Serialize(xmlWriter, data, nameSpaces);
                    xml =  stringWriter.ToString();
                    var xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(xml);
                    if (removeEmptyNodes)
                    {
                        RemoveEmptyNodes(xmlDocument);
                    }
                    xml = xmlDocument.InnerXml;
                }
            }
