    public class Teacher
    {
        public Teacher()
        {
            Student = new HashSet<Student>();
        }
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Student { get; set; }
    }
