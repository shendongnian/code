    public interface INamed { string Name { get; } }
  
    public class SomeType : INamed { ... }
    var listObjects = new List<SomeType>() { /* populate collection */ };
    var foundObject = listObjects.Where( x => x.Name == "theNameToFind" )
                                 .SingleOrDefault();
   
