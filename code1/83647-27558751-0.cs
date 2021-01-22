        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlArray("FormatStyleTemplates")]
        [XmlArrayItem("FormatStyle")]
        public XmlAnything<IFormatStyle>[] FormatStyleTemplatesXML
        {
            get
            {
                return FormatStyleTemplates.Select(t => new XmlAnything<IFormatStyle>(t)).ToArray();
            }
            set
            {
                // read the values back into some new object or whatever
                m_FormatStyleTemplates = new FormatStyleProvider(null, true);
                value.ForEach(t => m_FormatStyleTemplates.Add(t.Value));
            }
        }
