        public class Contact
        {
            public string ContactName { get; set; }
            public string ContactEmail { get; set; }
            public bool АvailableContactEmail { get; set; }
            public string ContactMobile { get; set; }
            public bool АvailableContactMobile { get; set; }
        }
        public class Student
        {
            public int StudentId { get; set; }
            public string StudentName { get; set; }
            public List<Contact> Contacts { get; set; }
        }
        public class StudentData
        {
            public List<Student> Students { get; set; }
        }
        public class RootObject
        {
            public StudentData StudentData { get; set; }
        }
