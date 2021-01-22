    public class MyClass
    {
        public static string MyStaticMethod()
        {
            string className = typeof(MyClass).Name;
            Console.WriteLine(className);
        }
    }
    public class MyOtherClass : MyClass{ }
