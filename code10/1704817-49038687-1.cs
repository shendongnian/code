    public class School
    {
        [Key] //I assume it is a PK
        public string schoolCode { get; set; }
        public string schoolName { get; set; }
        
        public virtual ICollection<Student> Students { get; set; }
    }
