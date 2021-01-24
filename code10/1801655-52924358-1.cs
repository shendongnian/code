    class Listing
    {
        public int ID { get; set; }
        // every Listing has zero or more categories (many-to-many)
        public virtual ICollection<Category> Categories { get; set; }    
        ...
    }
    class Category
    {
        public int ID { get; set; }
        // every Category is used by zero or more Listings (many-to-many)
        public ICollection<Listing> Listings { get; set; }
        ...
        public bool Enabled {get; set;}
    }
