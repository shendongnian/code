    public class Vote {
        [Key]
        public int ID { get; set; }
        [Required]
        public virtual User Voter { get; set; }
        [Required]
        public virtual User TargetUser { get; set; }
        [Required]
        public int Decision { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
    }
