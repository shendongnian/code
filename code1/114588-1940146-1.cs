    public class SerializableFont
    {
        public SerializableFont()
        {
            FontValue = null;
        }
        public SerializableFont(Font font)
        {
            FontValue = font;
        }
        [XmlIgnore]
        public Font FontValue { get; set; }
        [XmlElement("FontValue")]
        public string SerializeFontAttribute
        {
            get
            {
                return FontXmlConverter.ToBase64String(FontValue);
            }
            set
            {
                FontValue = FontXmlConverter.FromBase64String(value);
            }
        }
        public static implicit operator Font(SerializableFont serializeableFont)
        {
            if (serializeableFont == null )
                return null;
            return serializeableFont.FontValue;
        }
        public static implicit operator SerializableFont(Font font)
        {
            return new SerializableFont(font);
        }
    }
