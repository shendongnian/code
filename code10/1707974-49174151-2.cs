    class Genre
    {
        public int Id { get; set; }
        // every Genre belongs to only one Museum using foreign key
        public int MuseumId { get; set; }
        public virtual Museum Museum { get; set; }
        // every Genre is performed by zero or more Artists (many-to-many)
        public virtual ICollection<Artist> Artists { get; set; }
        public string Name { get; set; }
    }
