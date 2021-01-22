    class Program
    {
        static void Main(string[] args)
        {
            SomeClass sc = new SomeClass();            
        }
    }
    [AttributeUsage(AttributeTargets.Field)]
    public class MyAttribute : System.Attribute
    {
        public readonly bool Foo;
        public MyAttribute(bool foo)
        {
            Foo = foo;
        }
       
    }
    class SomeClass
    {
        [MyAttribute(true)]
        public MyType myObject;
        [MyAttribute(true)]
        public int myInt;
        public bool myBool;
        public SomeClass()
        {
            SomeOtherClass.MyFunction(this);
        }
    }
    static class SomeOtherClass
    {
        public static void MyFunction(SomeClass sClass)
        {
            sClass.myObject = new MyType() { Name = "Test1"};
            foreach(FieldInfo finfo in  GetFeilds(sClass))
                Console.WriteLine(finfo.GetValue(sClass));
        }
        public static IEnumerable<FieldInfo> GetFeilds(SomeClass sClass)
        {
            foreach (FieldInfo field in typeof(SomeClass).GetFields())
            {
                foreach (Attribute attr in field.GetCustomAttributes(true))
                {
                    if (field.GetCustomAttributes(typeof(MyAttribute), true)!= null && ((MyAttribute)attr).Foo)
                        yield return field;
                }
            }            
        }
    }
    
    class MyType
    {
        public string Name;
    }   
