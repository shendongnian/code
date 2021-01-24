    public class Song
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        //navigation property
        public virtual List<Singer> Singers { get; set; }
    }
    public class Singer
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Song")]
        [Required]
        public string SongId { get; set; }
        [Required]
        public string Name { get; set; }
        //navigation property
        public virtual Song Song { get; set; }
    }
