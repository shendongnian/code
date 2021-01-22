    class FooView : IFooView
    {
        private readonly IFooPresenter presenter;
        public FooView(IFooPresenter presenter)
        {
            this.presenter = presenter;
        }
    }
    class FooPresenter1 : IFooPresenter
    {
        private readonly IFooView view;
        public FooPresenter()
        {
            view = new FooView(this);
        }
    }
    // or
    class FooPresenter2 : IFooPresenter
    {
        private readonly IFooView view;
        public FooPresenter(IFooView view)
        {
            this.view = view;
            view.Presenter = this;
        }
    }
