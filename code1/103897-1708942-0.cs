    [Serializable()]
    [XmlRoot(ElementName="Root")]
    public sealed class SomeObject
    {
        
        private BaseObject _Object;
        
        [XmlElement(Type=typeof(App.Projekte.Projekt), ElementName="Projekt")]
        [XmlElement(Type=typeof(App.Projekte.Task), ElementName="Task")]
        [XmlElement(Type=typeof(App.Projekte.Mitarbeiter), ElementName="Mitarbeiter")]
        public BaseObject Object
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
