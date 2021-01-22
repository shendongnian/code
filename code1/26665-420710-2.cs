    [DataContract]
    public class Person
    {
        [DataMember]
        public int ID { get; internal set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
    }
    ...
    static void Main()
    {
        Person person = new Person();
        person.Age = 27;
        person.Name = "Patrik";
        person.ID = 1;
        DataContractSerializer serializer = new DataContractSerializer(typeof(Person));
        XmlWriter writer = XmlWriter.Create(@"c:\test.xml");
        serializer.WriteObject(writer, person);
        writer.Close();
    }
