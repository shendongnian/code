    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
    }
    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
    
        public ICollection<Student> Student { get; set; }
    }
