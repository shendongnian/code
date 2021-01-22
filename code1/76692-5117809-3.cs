    [XmlType("SuperPerson")] // define Type
    public class SuperPerson : Person
    {
        [XmlArray("Skills")]
        [XmlArrayItem("Skill")]
        public List<String> Skills { get; set; }
        [XmlElement("Alias")]
        public string Alias { get; set; }
        public SuperPerson() 
        {
            Skills = new List<String>();
        }
        public SuperPerson(string name, string city, int age, string id, string[] skills, string alias)
        {
            Skills = new List<String>();
            this.Name = name;
            this.City = city;
            this.Age = age;
            this.ID = id;
            foreach (string item in skills)
            {
                this.Skills.Add(item);   
            }
            this.Alias = alias;
        }
    }
