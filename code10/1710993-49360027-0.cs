    public class Parent
    {
       [Key]
       public int Id { get; set; }
       public string Name { get; set; }
       public virtual Child Child { get; set; }
    }
    public class Child
    {
       [Key]
       public int Id { get; set; }
       public string Name { get; set; }
       public virtual Parent Parent { get; set; }
    }
   
    public class ParentMap : EntityTypeConfiguration<Parent>
    {
        public ParentMap ()
        {
            HasOptional(t => t.Child).WithRequired(t => t.Parent);
        }
    }
