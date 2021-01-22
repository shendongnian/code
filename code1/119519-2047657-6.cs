    public class MyFacade
    {
        private IMyInterface dep;
        public MyFacade WithDependency(IMyDependency dependency)
        {
            this.dep = dependency;
            return this;
        }
        public Foo CreateFoo()
        {
            return new Foo(this.dep ?? new DefaultDependency());
        }
    }
