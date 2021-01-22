    [Serializable]
    public class SerializableFont
    {
        public SerializableFont()
        {
            this.Font = null;
        }
    
        public SerializableFont(Font font)
        {
            this.Font = font;
        }
    
        [XmlIgnore]
        public Font Font { get; set; }
    
        [XmlElement("Font")]
        public string FontString
        {
            get
            {
                if (font != null)
                {
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                    return converter.ConvertToString(this.Font);
                }
                else return null;
            }
            set
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                this.Font = converter.ConvertFromString(value);
            }
        }
    }
