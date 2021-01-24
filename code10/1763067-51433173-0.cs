    public class Person
    {
        public string Name { get; set; } = "No name";
        [XmlIgnore]
        public int Age { get; set; } = 5;
        public string Gender { get; set; } = "Female";
        public Person(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        public Person() { }
    }
