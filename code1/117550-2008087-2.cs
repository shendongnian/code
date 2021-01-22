    public abstract class ViewBasePage<TPresenter, TView> : Page, IView
            where TPresenter : Presenter<TView>
            where TView : IView
    {
        protected TPresenter _presenter;
        public TPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = (TView) ((IView) this);
            }
    }
