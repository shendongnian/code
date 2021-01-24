    public class Degree
    {
        public Course Course { get; set; }
        public Degree()
        {
            Course = new Course();
        }
    }
    public class Course
    {
        public Student Student { get; set; }
        public Course()
        {
            Student = new Student();
        }
    }
    public class Student
    {
        public Student()
        {
        }
    }
