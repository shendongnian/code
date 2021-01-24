    public abstract class BaseService
    {
        protected Foo Foo { get; set; }
        protected Bar Bar { get; set; }
    
        public BaseService(IServiceProvider provider)
        {
            Foo = provider.GetService<Foo>();
            Bar = provider.GetService<Bar>();
        }
    }
    public class Service : BaseService
    {
        public Service(IOtherDependency otherDependency, IServiceProvider provider) : base(provider) { }
    
        public void Method()
        {
            var value = Bar.value;
            Foo.Do(value);
        }
    }
