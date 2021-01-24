        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Student(Student std)
            {
                FirstName = std.FirstName;
                LastName = std.LastName;
            }
        }
