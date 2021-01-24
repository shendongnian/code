    public interface IDbOperation<out TResult>
    {
        TResult Result { get; }
        void Execute(IDbConnection connection);
    }
