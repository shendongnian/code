    namespace NS
    ...
    
    public static class Utility {
        public static void Something(this object input) { ...
        
        public static void Something(this string input) { ...
    }
    // Works fine, resolves to 2nd method
    "test".Something();
    // At compile time C# converts the above to:
    Utility.Something("test");
