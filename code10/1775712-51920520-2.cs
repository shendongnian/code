    interface IStore
    {
        void Save(int id, string data);
        string Read(int id);
    }
    interface IAsyncStore : IStore
    {
        Task SaveAsync(int id, string data);
        Task<string> ReadAsync(int id);
    }
