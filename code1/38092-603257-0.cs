    public class Parent1
    {
        public static void Foo()
        {
            Console.WriteLine("Parent1");
        }
    }
    
    public class Child : Parent1
    {
        public new static void Foo()
        {
            Type parent = typeof(Child).BaseType;
            MethodInfo[] methods = parent.GetMethods();
            MethodInfo foo = methods.First(m => m.Name == "Foo");
            foo.Invoke(null, null);
        }
    }
