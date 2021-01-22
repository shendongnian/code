    public partial class Foo : Page, IFooView {
        private FooPresenter presenter;
    
        public Foo() {
            var factory = IoCResolve<FooPresenterFactory>();
            this.presenter = factory(this);
        }
    }
