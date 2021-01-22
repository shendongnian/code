    class Post {
      [Key]
      public int ID {get; set}
      public int MetaID { get; set; }
      public virtual Meta Meta {get; set;}
    }
