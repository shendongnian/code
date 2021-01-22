        [WebMethod]
        public void Reports(string xml)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(SystemInfo));
            SystemInfo obj = (SystemInfo)mySerializer.Deserialize(new StringReader(xml));
        }
