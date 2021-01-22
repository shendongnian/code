    internal class LocalDataObjectEngine_Cache : ISimpleCache<IBrokeredDataObject>
    {
        ISimpleCache<IBrokeredDataObject> _cache;
    
        ...
    
        public void ResetCache();
        {
            //logic here with access to IBrokeredDataObject if needed
        }
    
        ...
    }
