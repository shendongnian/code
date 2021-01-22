    public interface IViewBase { }
    public interface IPresenterBase<T> where T : IViewBase
    {
        T View { get; set; }
    }
    public interface ILogPresenter : IPresenterBase<ILogView> { }
    public interface ILogView : IViewBase { }
    public class LogPresenter : ILogPresenter
    {
        public ILogView View { get; set; }
    }
