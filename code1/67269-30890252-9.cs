    [XmlRoot("School")]
    public class School
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
    
        [XmlElement("Student")]
        public List<Student> Students { get; set; }
    }
    
    [XmlRoot("Student")]
    public class Student
    {
        [XmlAttribute("Index")]
        public int Index { get; set; }
    }
