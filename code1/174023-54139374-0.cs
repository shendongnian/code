        using System.Windows.Media;
        public class XmlColor
        {
            private Color m_color;
    
            public XmlColor() { }
            public XmlColor(Color c) { m_color = c; }
    
            public static implicit operator Color(XmlColor x)
            {
                return x.m_color;
            }
    
            public static implicit operator XmlColor(Color c)
            {
                return new XmlColor(c);
            }
    
            [XmlText]
            public string Default
            {
                get { return m_color.ToString(); }
                set { m_color = (Color)ColorConverter.ConvertFromString(value); }
            }
        }
    }
