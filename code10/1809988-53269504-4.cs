    public class WindsorFooFactory : IFooFactory
    {
        private readonly IWindsorContainer _container;
        public WindsorFooFactory(IWindsorContainer container)
        {
            _container = container;
        }
        public Foo Create()
        {
            return _container.Resolve<Foo>();
        }
        public void Release(Foo created)
        {
            _container.Release(created);
        }
    }
