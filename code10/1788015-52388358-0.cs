    public abstract class Program 
    {
        public bool BaseMethod() {}
    }
    public class Foo : Program 
    {
        public bool CustomFooMethod() {}
    }
    public class Bar : Program 
    {
        public bool CustomBarMethod() {}
    }
