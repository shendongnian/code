    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating MyClass instance");
            MyClass mc = new MyClass();
            Console.WriteLine("Setting value in MyClass instance");
            mc.Value = 1;
            Console.WriteLine("Getting attributes for MyClass type");
            object[] attributes = typeof(MyClass).GetCustomAttributes(true);
        }
    
    }
    
    [AttributeUsage(AttributeTargets.All)]
    public class MyAttribute : Attribute
    {
        public MyAttribute()
        {
            Console.WriteLine("Running constructor");
        }
    }
    
    [MyAttribute]
    class MyClass
    {
        public int Value { get; set; }
    }
