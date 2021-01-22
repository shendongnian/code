    public class EmbedScript
    {
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlText]
        public string Script { get; set; }
        public EmbedScript(string type, string script)
        {
            Type = type;
            Script = new System.Xml.XmlDocument().CreateCDataSection(script).OuterXml;
        }
        public EmbedScript()
        {
        }
    }
