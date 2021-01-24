    class Section
    {
        public int Id { get; set; }
        public string SectionName { get; set; }
        // every section has zero or more Categories (one-to-many)
        public virtual ICollection<Category> Categories {get; set;}
    }
    class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        // every Category belongs to exactly one Section using foreign key:
        public int SectionId { get; set; }
        public virtual Section Section {get; set;}
        // every Category has zero or more Records (one-to-many)
        public virtual ICollection<Record> Records {get; set;}
    }
    class Record
    {
        public int Id { get; set; }
        public string RecordName { get; set; }
        // every Record belongs to exactly one Category
        public int CategoryId { get; set; }
        public virtual Category Category {get; set;}
    }
