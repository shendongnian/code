    public class MyClass {
    
        private static readonly string[] myArray = { ... };
        private static readonly IList<string> myArrayReadOnly = Array.AsReadOnly(myArray);
    
        public static IList<string> MyArray {
            get {
                return myArrayReadOnly;
            }
        }
    
    }
