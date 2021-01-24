    class Foo
    {
        protected readonly ApplicationModelFactory _factory;
        public Foo(ApplicationModelFactory injected)
        {
            _factory = injected;
        }
        protected ApplicationModel[] => _factory.Model;
        public void Bar()
        {
            DoSomethingWithModel(this.ApplicationModel);
        }
    }      
