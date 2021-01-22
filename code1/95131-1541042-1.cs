    static void Main()
    {
        var myclass = typeof(MyClass);
        var pi = myclass.GetProperty("Enum");
        var type = pi.PropertyType;
    
        /* as itowlson points out you could just do ...
            var isMyEnum = type == typeof(MyEnum) 
            ... becasue Enums can not be inherited
        */
        var isMyEnum = type.IsAssignableFrom(typeof(MyEnum)); // true
    }
    public enum MyEnum { A, B, C, D }
    public class MyClass
    {
        public MyEnum Enum { get; set; }
    }
