        public class PersonDto
        {
          [XmlAttribute(AttributeName = "person-id")]
          public int Id { get; set; }
          [XmlAttribute(AttributeName = "person-name")]
          public string Name{ get; set; }
        }
