    public class Course
    {
        public override string ToString()
        {
            return $"{Name}";
        }
        public string Name { get; set; }
        public List<Student> Students = new List<Student>();
        public List<Student> FacultyMems = new List<Faculty>();
    }
