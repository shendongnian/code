    public abstract class BaseService
    {
        protected Foo Foo { get; set; }
        protected Bar Bar { get; set; }
    
        public BaseService(Foo foo, Bar bar)
        {
            Foo = foo;
            Bar = bar;
        }
    }
    public class Service : BaseService
    {
        public Service(IOtherDependency otherDependency, Foo foo, Bar bar) : base(foo, bar) { }
    }
