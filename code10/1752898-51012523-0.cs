        public long Id { get; set; }
        public long? OtherLinkId { get; set; } = null;
    
        [ForeignKey("OtherLinkId")]
        public Link OtherLink { get; set; }
    }
