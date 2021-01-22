    public class Student : Entity<Guid>
    {
    }
    public class Staff : Entity<Guid>
    {
    }
    public class Class : Entity<Guid>
    {
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
    }
