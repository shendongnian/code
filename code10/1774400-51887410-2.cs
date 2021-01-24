    internal class MartenTableMetaDataCustomer : MartenTableMetaDataBase
    {
        protected override void SetSpecificTableMetaData(StoreOptions storeOptions)
        {
            storeOptions.Schema.For<Customer>().Index(x => x.Muni);
        }
    }
