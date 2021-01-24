    public class DeskReading
    {
        public int DeskReadingId { get; set; }
        [Column(TypeName="datetime")]
        public DateTime Timestamp { get; set; }
    }
