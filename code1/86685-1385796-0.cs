        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.Read();
            this.C = reader.ReadElementString();
            this.D = reader.ReadElementString();
            reader.Read();
        }
