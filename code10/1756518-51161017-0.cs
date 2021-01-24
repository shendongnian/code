        [Key]
        public int ID { get; set; }
    
        [Required]
        [StringLength(50)]
        public string NAME { get; set; }
    
        [Required]
        [StringLength(50)]
        public string PASSWORD { get; set; }
