    class DataSourceBase
    {
    }
    class DataSource1 : DataSourceBase
    {
    }
    class TestDataPerMarket<TDataSource> where TDataSource : DataSourceBase
    {
        public int product {get;set;}
        public TDataSource datasource {get;set;}
    }
    public Interface IGeneral
    {
        void SetTestData<TDM<TDS>>(TDM<TDS> testData) 
            where TDM : class, 
            where TDS : DataSourceBase;
    }
