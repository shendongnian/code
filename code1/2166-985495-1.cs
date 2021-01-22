    [XmlRoot("ClassWithAbstractCollection")]
    public class ClassWithAbstractCollection
    {
        private List<AbstractType> _list;
        [XmlArray("ListItems")]
        [XmlArrayItem("ListItem", Type = typeof(AbstractXmlSerializer<AbstractType>))]
        public List<AbstractType> List
        {
            get { return _list; }
            set { _list = value; }
        }
        private AbstractType _prop;
        [XmlElement("MyProperty", Type=typeof(AbstractXmlSerializer<AbstractType>))]
        public AbstractType MyProperty
        {
            get { return _prop; }
            set { _prop = value; }
        }
        public ClassWithAbstractCollection()
        {
            _list = new List<AbstractType>();
        }
    }
