    public abstract class ViewBasePage<TPresenter, TView> : 
            TView, Page where TPresenter : Presenter<TView> where TView : IView
    {
        protected TPresenter _presenter;
    
        public TPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = GetView(); // <- Works
                //_presenter.View = (TView)this; <- Doesn't work
            }
        }
    
        /// <summary>
        /// Gets the view. This will get the page during the ASP.NET
        /// life cycle where the physical page inherits the view
        /// </summary>
        /// <returns></returns>
        private static TView GetView()
        {
            return (TView) HttpContext.Current.Handler;
        }
    }
