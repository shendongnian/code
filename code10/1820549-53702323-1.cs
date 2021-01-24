    class Like
    {
         public int Id {get; set;}
         public bool IsLiked {get; set;}
         ...
         // every Like belongs to exactly one Material, using foreign key
         public int MaterialId {get; set;}
         public virtual Material Material {get; set;}
    }
 
    class Visitor
    {
         public int Id {get; set;}
         ...
         // every Visitor belongs to exactly one Material, using foreign key
         public int MaterialId {get; set;}
         public virtual Material Material {get; set;}
    }
