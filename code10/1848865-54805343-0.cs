    public class Location 
    {
      public virtual int Id { get; set; }
      public virtual string ZipCode { get; set; }
      public virtual string Name { get; set; }
      public virtual bool IsSystem { get; set; } // just use a boolean column in the table for this one
    }
