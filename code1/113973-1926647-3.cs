    public partial class Foo : Page, IFooView
    {
        private readonly FooPresenter presenter;
        public Foo()
        {
            this.presenter = IoCResolve<IFooPresenter>(new MvpViewParameter(this));
        }
    }
