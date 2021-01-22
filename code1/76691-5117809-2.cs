    [XmlType("SpecialPerson")] // define Type
    public class SpecialPerson : Person
    {
        [XmlElement("SpecialInterests")]
        public string Interests { get; set; }
        public SpecialPerson() { }
        public SpecialPerson(string name, string city, int age, string id, string interests)
        {
            this.Name = name;
            this.City = city;
            this.Age = age;
            this.ID = id;
            this.Interests = interests;
        }
    }
