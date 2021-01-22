        static public string BeautifyXml(XmlDocument doc, Encoding encoding)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.NewLineChars = "\r\n";
            settings.NewLineHandling = NewLineHandling.Replace;
            String xmlText;
            using (MemoryStream memstream = new MemoryStream())
            using (StreamWriter sr = new StreamWriter(memstream, encoding))
            using (XmlWriter writer = XmlWriter.Create(memstream, settings))
            {
                doc.Save(writer);
                xmlText = encoding.GetString(memstream.GetBuffer(), 0, (Int32)memstream.Length);
            }
            return xmlText;
        }
