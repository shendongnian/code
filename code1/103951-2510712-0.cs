     System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(header.GetType());
            XmlTextWriterFull writer = new XmlTextWriterFull(FilePath);
            x.Serialize(writer, header);
            writer.Flush();
            writer.BaseStream.Dispose();
            string xml = File.ReadAllText(FilePath);
            xml = xml.Replace(" xsi:nil=\"true\"", "");
            File.WriteAllText(FilePath, xml);
