    public interface IViewBase { }
    
    public interface IPresenterBase<T> where T : IViewBase
    {
        T View { get; set; }
    }
