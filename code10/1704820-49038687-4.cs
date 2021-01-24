    public class School
    {
        [Key] //I assume it is a PK
        public string schoolCode { get; set; }
        public string schoolName { get; set; }
        
        public virtual ICollection<Student> Students { get; set; }
    }
    public class Student
    {
        [Key]
        public Guid studentId { get; set; }
        public string studentName { get; set; }
        
        public string schoolCode { get; set; }
        [ForeignKey("schoolCode")]
        public virtual School School { get; set; }
    }
