    public partial class LocalDataObjectEngine : IEngine
    {
        ISimpleCache<IBrokeredDataObject> _cache  = new LocalDataObjectEngine_Cache();
    
        public void ResetCache<IBrokeredDataObject>()
        {
            _cache.ResetCache<IBrokeredDataObject>();
        }
    }
