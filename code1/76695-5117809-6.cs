    [XmlType("Person")] // define Type
    [XmlInclude(typeof(SpecialPerson)), XmlInclude(typeof(SuperPerson))]  
            // include type class SpecialPerson and class SuperPerson
    public class Person
    {
        [XmlAttribute("PersID", DataType = "string")]
        public string ID { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("City")]
        public string City { get; set; }
        [XmlElement("Age")]
        public int Age { get; set; }
        // Konstruktoren 
        public Person() { }
        public Person(string name, string city, int age, string id)
        {
            this.Name = name;
            this.City = city;
            this.Age = age;
            this.ID = id;
        }
    }
