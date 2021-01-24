    class Product
    {
        public int Id {get; set;}
        // every Product has zero or more Ratings:
        public virtual ICollection<Rating> Ratings {get; set;}
        // every product has zero or more Images:
        public virtual ICollection<Image> Images {get; set;}
        ... // other properties
    }
    class Rating
    {
        public int Id {get; set;}
      
        // every Rating belongs to exactly one Product using foreign key:
        public int ProductId {get; set;}
        public virtual Product Product {get; set;} 
        ...
    }
    class Image
    {
        public int Id {get; set;}
      
        // every Image belongs to exactly one Product using foreign key:
        public int ProductId {get; set;}
        public virtual Product Product {get; set;} 
        ...
    }
