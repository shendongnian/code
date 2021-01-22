    public interface IXyz
    {
        void Foo();
    }
    
    public class Xyz : IXyz
    {
        public void Foo()
        {
        }
    }
    
    public class Sut
    {
        public void Bar(IXyz xyz)
        {
            xyz.Foo();
        }
    }
