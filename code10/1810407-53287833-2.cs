    class Foo
    {
        protected readonly IApplicationModelFactory _factory;
        public Foo(IApplicationModelFactory injected)
        {
            _factory = injected;
        }
        protected ApplicationModel[] => _factory.Model;
        public void Bar()
        {
            DoSomethingWithModel(this.ApplicationModel);
        }
    }      
