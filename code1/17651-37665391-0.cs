    [Serializable]
        public class FoobarXml
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public bool IsContent { get; set; }
    
            [XmlElement(DataType = "date")]
            public DateTime BirthDay { get; set; }
        }
