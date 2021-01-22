        [OperationContract]
        XmlElement GetXml(string path);
    ...
        public XmlElement GetXml(string path) {
            var doc = new XmlDocument();
            doc.Load(path); // TODO: add security...
            return doc.DocumentElement;
        }
