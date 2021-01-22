    using Company.Foo;
    using Company.Foo.Models;
    
    namespace Company.Foo
    {
        class Program {
            public static void Main() {}
        }
    }
    
    namespace Company.Foo.Models
    {
        public class Foo { }
    
    }
    
    public class DataContextClass
    {
        public Foo DataContext { get; set; } /* Foo here is automatically resolved to Company.Foo.Models.Foo */
    }
