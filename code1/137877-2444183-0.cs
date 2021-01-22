    public interface IMyInterface
    {
        public void Foo();
        public IList<string> Properties{get;}
    }
    public class ConcreteClass : IMyInterface
    {
        public void Foo(){}
        public IList<string> Properties
        {
            get{ return s_properties; }
        }
    }
