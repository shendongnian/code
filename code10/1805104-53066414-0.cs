    public class ClassA : BaseClass, IXmlSerializable
    {
        [XmlElement("name/text")]
        public string Name
        {
            get { return GetProperty(() => Name); }
            set { SetProperty(() => Name, value); }
        }
    }
