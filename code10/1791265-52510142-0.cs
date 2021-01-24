    public interface ISyncManager<T,U,V> where T : IOfflineBackedRepo<U,V>
    {
        void Register(T repo);
    
        Task SyncNowAsync(); // this loops through and calls SyncAsync on the repo
    }
