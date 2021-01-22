    public class MyFacade
    {
        private IMyDependency dep;
        public MyFacade()
        {
            this.dep = new DefaultDependency();
        }
        public MyFacade WithDependency(IMyDependency dependency)
        {
            this.dep = dependency;
            return this;
        }
        public Foo CreateFoo()
        {
            return new Foo(this.dep);
        }
    }
