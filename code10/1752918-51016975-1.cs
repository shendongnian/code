     public class ErrorLog
    {
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Error { get; set; }
        [Required]
        [StringLength(4000)]
        public string Details { get; set; }
        public int? UserId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
