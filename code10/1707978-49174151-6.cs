    class Museum
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // every Museum has zero or more Artists (one-to-many)
        public virtual ICollection<Artist> Artists { get; set; }
        // every Museum has zero or more Genres (one-to-many)
        public virtual ICollection<Genre> Genres { get; set; }
    }
