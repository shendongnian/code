    public interface IListable { string Name { get; } } // assumed interface
  
    public class SomeType : IListable { ... }
    var listObjects = new List<SomeType>() { /* populate collection */ };
    var foundObject = listObjects.Where( x => x.Name == "theNameToFind" )
                                 .SingleOrDefault();
