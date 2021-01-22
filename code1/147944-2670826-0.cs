    using System.Xml.Serialization;
    // ...
    [Serializable]
    public class Detail
    {
        [XmlElement]
        public string Name1 { get; set; }
        [XmlElement]
        public string Name2 { get; set; }
        // REQUIRED: a parameterless constructor for XmlSerializer (can be private)
        private Detail(){}
        public Detail(string name1, string name2)
        {
            Name1 = name1;
            Name2 = name2;
        }
    }
    [Serializable, XmlRoot("Details")]
    public class DetailList : List<Detail>
    {
        
    }
