    public post {
        [Key]
        [Required]
        [Column(Order = 0)]
        public long post_id { get; set; }
    
        [Required]
        [Column(Order = 1)]
        public long thread_id { get; set; }
    
        //[Required]
        [Column(Order = 2)]
        public long? parent_post { get; set; }
    
        [Required]
        [Column(Order = 3)]
        public long creator { get; set; }
    
        //[Required]
        [Column(Order = 4)]
        public DateTime? create_date { get; set; }
    
        //[Required]
        [Column(Order = 5)]
        public DateTime? update_date { get; set; }
    
        //[Required]
        [Column(Order = 6)]
        public string post_text { get; set; }
    }
