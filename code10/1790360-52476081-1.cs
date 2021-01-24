    public interface INotPersistingProperties
    {
       [NotMapped]
       string MyNotPersistingPropertyA { get; set; }
       [NotMapped]
       string MyNotPersistingPropertyB  { get; set; }
    }
    
    [MetadataType(typeof(INotPersistingProperties))]
    public class MyEntity : INotPersistingProperties
    {
      public int Id { get; set; }
      public string MyNotPersistingPropertyA { get; set; }
      public string MyNotPersistingPropertyB { get; set; }
    }
