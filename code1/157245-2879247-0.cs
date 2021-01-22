    namespace FruityNamespace {
      public static class FruityExtensions {
        public static string ToFunString(this int value) {return value + " bananas"; }
      }
    }
    
    namespace VegetablNamespace {
      public static class VegetablyExtensions {
        public static string ToFunString(this int value) {return value + " carrots"; }
      }
    }
    
    //In some other source file
    static void Main(/**/) {
      int things = 3;
      3.ToFunString(); //error CS1061: 'System.Int' does not contain a definition for 'ToFunString' and no extension method 'ToFunString' accepting a first argument of type 'System.Int' could be found (are you missing a using directive or an assembly reference?)
    }
