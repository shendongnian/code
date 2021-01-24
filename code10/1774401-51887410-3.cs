    internal class MartenTableMetaDataDriver : MartenTableMetaDataBase
    {
        protected override void SetSpecificTableMetaData(StoreOptions storeOptions)
        {
            storeOptions.Schema.For<Driver>().Index(x => x.Username);
        }
    }
