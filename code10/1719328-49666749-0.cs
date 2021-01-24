    container.Register(Component.For<Configuration>())
    public class Configuration
    {
        //your properties
    }
    public class Foo
    {
        public Foo(Configuration configuration)
        {
        }
    }
    public class Da
    {
        public Da(Configuration configuration)
        {
        }
    }
