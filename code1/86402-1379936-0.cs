    [XmlRoot("root")]
    public class Sample1Xml
    {
        internal Sample1Xml()
        {
        }
        [XmlElement("node")]
        public NodeType Node { get; set; }
        #region Nested type: NodeType
        public class NodeType
        {
            [XmlAttribute("attr1")]
            public string Attr1 { get; set; }
            [XmlAttribute("attr2")]
            public string Attr2 { get; set; }
            [XmlIgnore]
            public string Content { get; set; }
            [XmlText]
            public XmlNode[] CDataContent
            {
                get
                {
                    var dummy = new XmlDocument();
                    return new XmlNode[] {dummy.CreateCDataSection(Content)};
                }
                set
                {
                    if (value == null)
                    {
                        Content = null;
                        return;
                    }
                    if (value.Length != 1)
                    {
                        throw new InvalidOperationException(
                            String.Format(
                                "Invalid array length {0}", value.Length));
                    }
                    Content = value[0].Value;
                }
            }
        }
        #endregion
    }
