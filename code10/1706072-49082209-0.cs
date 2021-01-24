    public class Profile
    {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int ProfileId { get; set; }
    
      public virtual List<Dock> Docks { get; set; } = new List<Dock>();
    }
    
    public class Dock
    {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int DockId { get; set; }
      
      [ForeignKey("Profile")]
      public int ProfileId { get; set; }
      public Profile Profile {get; set; }
    } 
