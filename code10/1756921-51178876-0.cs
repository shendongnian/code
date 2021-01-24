    public class UProgram
    {
        public string Name { get; set; }
        public Degree Degree { get; set; }
        public UProgram(string name, Degree degree)
        {
            Name = name;
            Degree = degree;
        }
    }
    public class Degree
    {
        public string Name { get; set; }
        public Course Course { get; set; }
        public Degree(string name, Course course)
        {
            Name = name;
            Course = course;
        }
    }
    public class Course
    {
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }
        public string Name { get; set; }
        public Course(string name, List<Teacher> teachers, List<Student> students)
        {
            Name = name;
            Teachers = teachers;
            Students = students;
        }
    }
    public class Teacher
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
