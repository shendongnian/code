    internal abstract class MartenTableMetaDataBase : IMartenTableMetaData
    {
        public void SetTableMetaData(StoreOptions storeOptions)
        {
            SetSpecificTableMetaData(storeOptions);
        }
        protected abstract void SetSpecificTableMetaData(StoreOptions storeOptions);
    }
