        class Program
        {
            static void Main(string[] args)
            {
                SomeClass sc = new SomeClass();
            }
        }
        class SomeClass
        {
            public MyType myObject;
            public SomeClass()
            {
                SomeOtherClass.MyFunction(this);
            }
        }
    
        static class SomeOtherClass
        {
            public static void MyFunction(SomeClass sClass)
            {
                sClass.myObject = new MyType() { Name = "Test1" };
                FieldInfo[] fInfo = sClass.myObject.GetType().GetFields();
                Console.WriteLine(fInfo[0].GetValue(sClass.myObject));
            }
        }
        class MyType
        {
            public string Name;
        }
