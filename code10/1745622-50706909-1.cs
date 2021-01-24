    public class SomeModel
    {
        public DateTime StartDate { get; set; }
        [NotMapped]
        public bool IsActive { get; } => DateTime.UtcNow >= StartDate;
    
    }
