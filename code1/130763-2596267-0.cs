    [XmlRoot("Persons")]
    public class Persons 
    {
        public Persons ()
        {
            People = new List<Human>();
        }
        [XmlElement("Person")]
        public List<Human> People 
        { get; set; }
    }
    public class Human
    {
        public Human()
        {
        }
        public Human(string name)
        {
            Name = name;
        }
        [XmlElement("Name")]
        public string Name { get; set; }
    }
