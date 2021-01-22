    [Serializable()]
    [XmlRoot(ElementName="Object")]
    public sealed class XMLObject
    {
        
        private Object _Object;
        
        [XmlElement(Type=typeof(App.Projekte.Projekt), ElementName="Projekt")]
        [XmlElement(Type=typeof(App.Projekte.Task), ElementName="Task")]
        [XmlElement(Type=typeof(App.Projekte.Mitarbeiter), ElementName="Mitarbeiter")]
        public Object Object
        {
            get
            {
                return _Object;
            }
            set
            {
                _Object = value;
            }
        }
    }
