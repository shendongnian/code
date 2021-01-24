    public interface IDataCollector
    {
        void Add(IDataCollectable collectable);
        void CollectData();
    }
    public class DataCollector : IDataCollector
    {
        private readonly ICollectDataResultReceiver _resultReceiver;
        private readonly List<IDataCollectable> _collectables = new List<IDataCollectable>();
        
        public DataCollector(ICollectDataResultReceiver resultReceiver)
        {
            _resultReceiver = resultReceiver;
        }
        public void Add(IDataCollectable collectable)
        {
            _collectables.Add(collectable);
        }
        public void CollectData()
        {
            foreach(var collectable in _collectables)
            {
                collectable.CollectData(_resultReceiver);
            }
        }
    }
