    [XmlType("person")]
    public class Person
    {
        int personID;
        string name;
        [XmlElement("id")]
        public int PersonID
        {
            get { return personID; }
            set { personID = value; }
        }
        [XmlElement("name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
    …
    var serializer = new XmlSerializer(typeof(Person[]), new XmlRootAttribute("persons"));
    var result = (Person[])serializer.Deserialize(new StringReader(xml));
