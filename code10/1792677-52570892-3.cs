    public interface IDbOperation<TResult>
    {
        TResult Result { get; }
        void Execute(IDbConnection connection);
    }
