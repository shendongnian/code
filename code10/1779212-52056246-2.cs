    public class WorkPage
    {
        [Key]
        public int Id { get; set; }
    
        public byte CommissionPercentage { get; set; }
    
        public bool IsClosed { get; set; }
    
        public DateTime? DateClosed { get; set; }
    
        public int DriverId { get; set; }
    
        [ForeignKey(nameof(DriverId))]
        public Driver Driver { get; set; }
    }
    
    public class DriverWork
    {
        [Key]
        public int Id { get; set; }
    
        public string FromLocation { get; set; }
    
        public string ToLocation { get; set; }
    
        public int Price { get; set; }
    
        public DateTime Date { get; set; }
    
        public int WorkPageId { get; set; }
    
        [ForeignKey(nameof(WorkPageId))]
        public WorkPage WorkPage { get; set; }
    }
