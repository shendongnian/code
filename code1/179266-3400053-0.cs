      public class GlobalInformation {
         public static GlobalInformation CreateInstance() {
            // Factory method through GlobalInformmation.CreateInstance()
            return new GlobalInformation();
         }
         public GlobalInformation() {
            // Regular use through new GlobalInformation()
         }
         static GlobalInformation() {
            // Static initializer called once before class is used.
            // e.g. initialize values:
            _aString = "The string value";
         }
         public string AccessAString {
            get {
               return _aString;
            }
         }
         public Foo AccessAnObject() {
            return _anObject;
         }
         private static string _aString;
         private static readonly Foo _anObject = new Foo();
      }
