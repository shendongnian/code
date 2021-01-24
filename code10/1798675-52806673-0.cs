    public class Batch
    {
        public string Name { get; set; }
        public int Fee { get; set; }
        public int Duration { get; set; }
        public List<Student> Students { get; set; }
    }
    public class Student
    {
        public string Name { get; set; }
        public int RollNumber { get; set; }
        // Date of birth instead of age, as explained in comment by Dour High Arch.
        public DateTime DateOfBirth { get; set; } 
    }
