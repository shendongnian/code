    internal interface IFoo
    {
        void Frob();
    }
    public interface IBar
    {
        void Blah();
    }
    public class Foo : IFoo, IBar 
    {
        void IFoo.Frob() { }
        public void Blah() { }
    }
