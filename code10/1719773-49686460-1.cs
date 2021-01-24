    public interface IDataRecievable<T>
    {
        T GetData();
    }
    public interface IDataCollectable
    {
        void CollectData(ICollectDataResultReceiver resultReceiver);
    }
