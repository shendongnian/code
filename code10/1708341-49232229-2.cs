    [XmlRoot("dform")]
    public class DForm
    {
        [XmlElement("textmemo", Type=typeof(Textmemo))]
        [XmlElement("label", Type=typeof(Label))]
        [XmlElement("section", Type=typeof(Section))]
        public List<Widget> Widgets { get; } = new List<Widget>();
    }
