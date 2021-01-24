    public class Child
    {
      [Key,ForeignKey("Parent")]
      public int ParentId { get; set; }
      public string Name { get; set; }
      public virtual Parent Parent { get; set; }
    }
