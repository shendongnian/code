    public abstract class AbstractPresenter<TView, TPresenter> : IPresenter<TView, TPresenter>
        where TView : IView<TPresenter>
        where TPresenter : class, IPresenter<TView, TPresenter>
    {
        protected TView view;
        public TView View
        {
            get { return this.view; }
            set
            {
                this.view = value;
                this.view.Presenter = this as TPresenter;
            }
        }
    }
