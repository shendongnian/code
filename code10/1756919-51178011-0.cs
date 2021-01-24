    public class Degree
    {
        public Degree()
        {
            Course = new Course();
        }
        public Course Course { get; set; }
    }
    public class Course
    {
        public Course()
        {
            Student = new Student();
        }
        public Student Student { get; set; }
    }
    public class Student
    {
        public Student()
        {
        }
    }
