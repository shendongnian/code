    interface IDataManager
    {
        void WriteData(Stream stream);
        IDataCollectionPolicy Policy { get; set; }
        IDataManager NextDataManager { get; set; }
    }
    
    interface IDataManager<T, K> : IDataManager
    {
        T GetData(K args);
        void WriteData(T data, Stream stream);
    }
