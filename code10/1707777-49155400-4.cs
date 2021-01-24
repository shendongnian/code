    public interface IBase
    {
        void Baz();
    }
    public interface IFoo : IBase
    {
        void FooSpecificMethod();
    }
    public interface IBar : IBase
    {
        void BarSpecificMethod();
    }
    public class BaseBaz : IBase
    {
        public void Baz()
        {
            // totes baz;
        }
    }
    public class Foo : BaseBaz, IFoo
    {
        public void FooSpecificMethod()
        {
            // foo
        }
    }
    public class Bar : BaseBaz, IFoo
    {
        public void BarSpecificMethod()
        {
            // not foo
        }
    }
