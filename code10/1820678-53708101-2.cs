        public class Student
        {
            //...
            public ICollection<Course> Courses { get; set; }
        }
        public class Course
        {
            public int Id { get; set; }
            //...
        }
