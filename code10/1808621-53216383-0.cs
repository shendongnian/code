    public class Course
    {
        public override string ToString()
        {
            return $"{Name}";
        }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<Faculty> FacultyMembers {get; set;} 
    
    }
