    class Program
    {
        static void Main(string[] args)
        {
            var myClassProps = typeof(MyClass).GetProperties();
    
            foreach (var prop in myClassProps.Where(p => p.Name == nameof(MyClass.XX)))
            {
                var attribs = prop.GetCustomAttributes(typeof(CustomAttribute), false);
    
                if (attribs.Length > 0)
                {
                    var customAttrib = attribs[0] as CustomAttribute;
    
                    //Do Something with it here
                }
            }
        }
    }
    
    public enum MyEnum
    {
        ABC = 0,
        XYZ = 1
    }
    
    
    public class CustomAttribute : Attribute
    {
        public bool MyProp1 { get; set; }
        public string MyProp2 { get; set; }
    }
    
    public class MyClass
    {
        [Custom(MyProp1 = true, MyProp2 = "test")]
        public bool X { get; set; } 
    
        [Custom(MyProp1 = true)]
        public MyEnum XX { get; set; }
    }
