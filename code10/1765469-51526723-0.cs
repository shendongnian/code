    public class Story
        {
            public int Id { get; set; }
    
            public string AuthorId { get; set; }
            public virtual ApplicationUser Author { get; set; }
    
            [Required]
            [StringLength(50)]
            public string Title { get; set; }
    
            [Required]
            [MinLength(100), MaxLength(5000)]
            public string Content { get; set; }
    
            [Required]
            public int GenreId { get; set; }
            public Genre Genre { get; set; }
    
            public int? StoryTypeId { get; set; }
            public StoryType StoryType { get; set; }
    
            public DateTime CreatedAt { get; set; }
        }
