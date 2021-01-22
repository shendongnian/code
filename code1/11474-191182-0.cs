    public interface IView<TPresenter>
    {
        TPresenter Presenter { get; set; }
    }
    public interface IPresenter<TView, TPresenter>
        where TView : IView<TPresenter>
        where TPresenter : IPresenter<TView, TPresenter>
    {
        TView View { get; set; }
    }
