    public interface IFoo
    {
        void FooMethod();
    }
    public interface IBar()
    {
        void BarMethod();
    }
    public class SmallClass : IFoo
    {
        public void FooMethod() { ... }
    }
    public class BigClass : IFoo, IBar
    {
        public void FooMethod() { ... }
        public void BarMethod() { ... }
    }
