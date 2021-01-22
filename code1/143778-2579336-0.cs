    public interface ICheckedMethod<TReturn, TParam>
    {
        TReturn Execute(TParam param);
        bool CanExecute { get; }
        event EventHandler CanExecuteChanged;
    }
