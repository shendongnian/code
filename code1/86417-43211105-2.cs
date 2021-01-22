    public class EmbedScript
    {
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlText]
        public XmlNode[] Script { get; set; }
        public EmbedScript(string type, string script)
        {
            Type = type;
            Script = new XmlNode[] { new XmlDocument().CreateCDataSection(script) };
        }
        public EmbedScript()
        {
        }
    }
