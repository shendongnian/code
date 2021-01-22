    [XmlRoot("PersonenListe")]
    [XmlInclude(typeof(Person))] // include type class Person
    public class PersonalList
    {
        [XmlArray("PersonenArray")]
        [XmlArrayItem("PersonObjekt")]
        public List<Person> Persons = new List<Person>();
        [XmlElement("Listname")]
        public string Listname { get; set; }
        // Konstruktoren 
        public PersonalList() { }
        public PersonalList(string name)
        {
            this.Listname = name;
        }
        public void AddPerson(Person person)
        {
            Persons.Add(person);
        }
    }
