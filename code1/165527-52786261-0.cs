    public class MyClass
    {
        internal MyClass() { }
        // This factory method will be accessible from external assemblies, making your class instantiable yet still "sealed"
        public static MyClass Create()
        {
            return new MyClass();
        }
    }
