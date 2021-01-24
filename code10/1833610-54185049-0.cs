    public class GeneralEntity
    {
      public Guid Id { get; set; }
      public User CreatedBy { get; set; } // renaming just for simplicity
      public User DeletedBy { get; set; } // renaming just for simplicity
    }
    public class GeneralEntityDto
    {
      public Guid Id { get; set; }
      public string CreatedByUsername { get; set; }
      public string DeletedByUsername { get; set; }
    }
