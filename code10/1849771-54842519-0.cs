    class Program
    {
        static void Main(string[] args)
        {
            ClassA classA = new ClassA();
            classA.method3(); // call the extra ClassA method you wrote
        }
    }
    
    // This class is assumed to be somewhere that you cannot modify
    public class ClassA
    {
        public void method1() { }
        public void method2() { }
    }
    
    // This is "ClassB" from your question, but I've renamed it to "ExtensionMethods"
    public static class ExtensionMethods
    {
        public static void method3(this ClassA classA) { }
    }
