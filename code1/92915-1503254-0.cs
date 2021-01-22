        public XmlReader FixUpReader(XmlReader reader)
        {
           reader.MoveToContent();
            string xml = reader.ReadOuterXml();
            string dslVersion = GetDSLVersion();
            string Id = GetID();
            string processedValue = string.Format("<ExampleElement dslVersion=\"{1}\" Id=\"{2}\" ", dslVersion, Id);
            xml = xml.Replace("<ExampleElement ", processedValue);
            MemoryStream ms = new MemoryStream(System.Text.Encoding.ASCII.GetBytes(xml));
            XmlReaderSettings settings = new XmlReaderSettings();
            XmlReader myReader = XmlReader.Create(ms);
            myReader.MoveToContent();
            return myReader;
        }
