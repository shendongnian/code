    public MyRandomEntity {
        public int Id { get; set; }
    
        // ...
    
        public DateTime CreatedDate { get; private set; } //mandatory
        public User CreatedBy { get; private set; } //mandatory
    
        public DateTime? UpdatedDate { get; set; } //optional
        public User? UpdatedBy { get; set; } //optional
    
        public DateTime? RemovedAt { get; set; } //optional
        public User? RemovedBy { get; set; } //optional
    }
