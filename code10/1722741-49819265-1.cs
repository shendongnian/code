    public class Foo<T>
    {
        public int field;
        public void Method() 
        {
            // I expect this to be an unspecialized reference
            int x = field;
        }
    }
    public class Bar
    {
        public void Method() 
        {
            Foo<string> foo = new Foo<string>();
            // I expect this to be a specialized field reference
            int x = foo.field;
        }
    }
