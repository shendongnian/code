    public static class Test {
        public static void Method(string s) { 
            Console.WriteLine("String version: " + s); 
        }
        public static void Method(object o) { 
            Console.WriteLine("Object version: " + o.ToString()); 
        }
        public static void Main(string[] args) { Method("my string"); }
    }
