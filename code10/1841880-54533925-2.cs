    public class Student {
        [XmlElement("name")]
        public string Name {get;set;}
        [XmlElement("semester")]
        public string Semester {get;set;}
    }
    [XmlRoot("persons")]
    public class SomeData {
        [XmlElement("student")]
        public List<Student> Students {get;} = new List<Student>();
    }
