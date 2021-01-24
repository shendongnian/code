    class Material
    {
         public int Id {get; set;}
         public string Title {get; set;}
         public string Content {get; set;}
         // every Material has zero or more Likes (one-to-many)
         public virtual ICollection<Like> Likes {get; set;}
         // every Material has zero or more Visitors (one-to-many)
         public virtual ICollection<Visitor> Visitors {get; set;}
    }
