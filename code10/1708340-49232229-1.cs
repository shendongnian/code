    public class Textmemo : Widget
    {
        public override string type { get; } = "CONTROL";
    }
    
    public class Label : Widget
    {
        public override string type { get; } = "LABEL";
    }
    
    public class Section : Widget
    {
        public override string type { get; } = "SECTION";
    
        [XmlElement("textmemo", Type=typeof(Textmemo))]
        [XmlElement("label", Type=typeof(Label))]
        [XmlElement("section", Type=typeof(Section))]
        public List<Widget> subsection { get; } = new List<Widget>();
    }
