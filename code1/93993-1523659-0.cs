    class Person
    {
        // XmlSerializer requires parameterless constructor
        public Person()
        {
        }
    
        public string Name { get; set; }
    
        public string Pass { get; set; }
    
        public string Email { get; set; }
    
        public string Host { get; set; }
    }
    
    // ...
    
    XmlSerializer serializer = new XmlSerializer(typeof(Person));
    
    // Write a person to an XML file
    Person person = new Person() { Name = "N", Pass = "P", Email = "E", Host = "H" };
    using (XmlWriter writer = XmlWriter.Create("person.xml"))
    {
        serializer.Serialize(writer);
    }
    
    // Read a person from an XML file
    using (XmlReader reader = XmlReader.Create("person.xml"))
    {
        person = (Person)serializer.Deserialize(reader);
    }
