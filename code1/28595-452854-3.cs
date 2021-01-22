    internal class LocalDataObjectEngine_Cache : ISimpleCache<IBrokeredDataObject>
    {
        ISimpleCache<IBrokeredDataObject> _cache;
    
        ...
    
        public void ResetCache<IBrokeredDataObject>();
        {
            //logic here
        }
    
        ...
    }
