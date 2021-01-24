    public interface IOfflineBackedRepo
    {
        Task SyncAsync(); // this function is not typed specific right?
    }
    public interface IOfflineBackedRepo<TSummary,TDetail> : IOfflineBackedRepo
    {
        // other definition about type specific
    }
    public interface ISyncManager<T> where T : IOfflineBackedRepo
    {
        void Register(T repo);
    
        Task SyncNowAsync(); // this loops through and calls SyncAsync on the repo
    }
