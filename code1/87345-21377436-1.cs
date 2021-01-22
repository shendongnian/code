    public class ActionsCDataField : IXmlSerializable
    {
        public List<Action> Actions { get; set; }
        public ActionsCDataField()
        {
            Actions = new List<Action>();
        }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void WriteXml(XmlWriter w)
        {
            foreach (var item in Actions)
            {
                w.WriteStartElement("Action");
                w.WriteAttributeString("Type", item.Type);
                w.WriteCData(item.InnerText);                
                w.WriteEndElement();
                w.WriteString("\r\n");
            }
        }
        public void ReadXml(XmlReader r)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(r);
            XmlNodeList nodes = xDoc.GetElementsByTagName("Action");
            if (nodes != null && nodes.Count > 0)
            {
                foreach (XmlElement node in nodes)
                {
                    Action a = new Action();
                    a.Type = node.GetAttribute("Type");
                    a.InnerText = node.InnerXml;
                    if (a.InnerText != null && a.InnerText.StartsWith("<![CDATA[") && a.InnerText.EndsWith("]]>"))
                        a.InnerText = a.InnerText.Substring("<![CDATA[".Length, a.InnerText.Length - "<![CDATA[]]>".Length);
                    
                    Actions.Add(a);
                }
            }
        }
    }
    public class Action
    {
        public String Type { get; set; }
        public String InnerText { get; set; }
    }
