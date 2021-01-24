    public class SomeModel
    {
        public DateTime StartDate { get; set; }
        public bool IsActive { get; } => DateTime.UtcNow >= StartDate;
    
    }
