     public static class SomeClass
    {
        public object void Columns(Func<Foo,object> action)
        {
            throw new Exception();
        }
    }
    public class Foo
    {
        public Foo Add()
        {
            return this;
        }
        public Foo Value(object value)
        {
            return this;
        }
        public Foo Text(string text)
        {
            return this;
        }
    }    
