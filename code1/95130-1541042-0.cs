    class Program
    {
        static void Main(string[] args)
        {
            var myclass = typeof(MyClass);
            var pi = myclass.GetProperty("Enum");
            var type = pi.PropertyType;
            var itMyEnum = type.IsAssignableFrom(typeof(MyEnum)); // true
        }
    }
    public enum MyEnum { A, B, C, D }
    public class MyClass
    {
        public MyEnum Enum { get; set; }
    }
