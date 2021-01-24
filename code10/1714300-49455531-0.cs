    public class History
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Id))]
        public IncomingData IncomingData { get; set; }
    }
