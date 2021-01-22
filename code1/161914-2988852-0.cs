    [DataContract]
    public class Student
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }
    [DataContract]
    public class StudentList
    {
        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public List<Student> Students { get; private set; }
        public StudentList(string name)
        {
            Name = name;
            Students = new List<Student>();
        }
    }
