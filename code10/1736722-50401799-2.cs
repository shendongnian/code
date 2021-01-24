    [XmlRoot(ElementName = "font")]
    public class Font : IEquatable<Font>
    {
        [XmlElement(ElementName = "size")]
        public string Size { get; set; }
        [XmlElement(ElementName = "fname")]
        public string Fname { get; set; }
        [XmlAttribute(AttributeName = "role")]
        public string Role { get; set; }
        public bool Equals(Font font)
        {
            if (font == null) return false;
            return (Size == font.Size) && (Fname == font.Fname) && (Role == font.Role);
        }
    }
    [XmlRoot(ElementName = "preferences")]
    public class Preferences
    {
        [XmlElement(ElementName = "font")]
        public List<Font> Font { get; set; }
    }
