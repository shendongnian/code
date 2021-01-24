    public class Album
    {
        [DisplayName("Album Id")]
        [Description("Album Id must be a positive integer")]
        [Range(1, Int32.MaxValue)]
        public int AlbumId { get; set; }
        [DisplayName("Artist Id")]
        [Description("Artist Id must be a positive integer")]
        [Range(1, Int32.MaxValue)]
        public int ArtistId { get; set; }
        [DisplayName("Title")]
        [Description("An Album Title is required")]
        [Required()]
        [StringLength(160)]
        public string Title { get; set; }
        [DisplayName("Album Price")]
        [Description("Album Price must be between 0.01 and 100.00")]
        [Range(0.01, 100.00)]
        public decimal Price { get; set; }
    }
