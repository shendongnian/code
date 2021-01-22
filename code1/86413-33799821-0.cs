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
                    XmlDocument dummy = new XmlDocument();
                    List<XmlNode> xmlNodes = new List<XmlNode>();
                    int tokenCount = 0;
                    int prevSplit = 0;
                    for (int i = 0; i < Content.Length; i++)
                    {
                        char c = Content[i];
                        //If the current character is > and it was preceded by ]] (i.e. the last 3 characters were ]]>)
                        if (c == '>' && tokenCount >= 2)
                        {
                            //Put everything up to this point in a new CData Section
                            string thisSection = Content.Substring(prevSplit, i - prevSplit);
                            xmlNodes.Add(dummy.CreateCDataSection(thisSection));
                            prevSplit = i;
                        }
                        if (c == ']')
                        {
                            tokenCount++;
                        }
                        else
                        {
                            tokenCount = 0;
                        }
                    }
                    //Put the final part of the string into a CData section
                    string finalSection = Content.Substring(prevSplit, Content.Length - prevSplit);
                    xmlNodes.Add(dummy.CreateCDataSection(finalSection));
    
                    return xmlNodes.ToArray();
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
