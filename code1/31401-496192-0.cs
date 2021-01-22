    public class Foo
    {
        public string Value;
    
        public static explicit operator string(Foo f)
        {
            return f.Value;
        }
    
    }
    
    public class Example
    {
        public void Convert()
        {
            var f = new Foo();
            f.Value = "abc";
    
            string cast = (string)f;
            string tryCast = f as string;
        }
    }
