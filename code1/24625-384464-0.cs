    public interface IFoo {}
    internal class Foo : IFoo {}
    public class Bar {
        protected void Test(IFoo foo) {}
    }
