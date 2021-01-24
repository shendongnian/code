    [ForeignKey("GenreId ")]
    public Genre Genre { get; set; }
    [Required]
    [Display(Name = "Genre")]
    public byte GenreId { get; set; }
