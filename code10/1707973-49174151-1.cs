    class Artist
    {
        public int Id { get; set; }
        // every Artist belongs to one Museum using foreign key:
        public int MuseumId { get; set; }
        public virtual Museum Museum { get; set; }
        // every Artist creates work in zero or more Genres (many-to-many)
        public virtual ICollection<Genre> Genres { get; set; }
		
        public string Name { get; set; }
    }
