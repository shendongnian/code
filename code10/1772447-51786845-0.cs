     public static class SomeClass
    {
        public static void Columns(Action<Foo> action)
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
