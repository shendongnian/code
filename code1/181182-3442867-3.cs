    public interface MSerializable {}
    public static class Serializable {
      public static void Serialize(this MSerializable self, string fileName) { 
        // self will refer to the right type, 
        // no need to use generics if all you want is to serialize it ...
      }
    }
    public class DirectChild : MSerializable { }
    public class InheritedChild : DirectChild { } 
    public class panelGenericIOGrid<T> where T: MSerializable, new() { } 
